using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using System.IO.Ports;
using System.Timers;
using System.Runtime.Serialization.Formatters.Binary;

using System.Text.RegularExpressions;
using System.IO;

using Thorlabs.MotionControl.DeviceManagerCLI;
using Thorlabs.MotionControl.IntegratedStepperMotorsCLI;

using Thorlabs.MotionControl.GenericMotorCLI.ControlParameters;
using Thorlabs.MotionControl.GenericMotorCLI.AdvancedMotor;
using Thorlabs.MotionControl.GenericMotorCLI.Settings;
using Thorlabs.MotionControl.KCube.SolenoidCLI;

//using Thorlabs.MotionControl.GenericMotorCLI.AdvancedMotor;
using System.Diagnostics;


namespace one_socket_thread
{
    delegate string Delegate_condi(string str);
    delegate string MyDelegate(string str);

    public partial class Form1 : Form
    {
        NetworkStream stream;
        //Binar
        Socket sock1;

        byte dummy = 0xff;
        byte stx = 0x02;
        byte etx = 0x03;
        byte nak = 0x15;
        byte rst = 0x12;
        byte ACK = 0x06;

        byte flag_ok = 0x30;
        byte flag_error = 0x31;  //send 부분에 else if로 검사 후 처리
        byte flag_fail = 0x32;

        public static string Out_string(string str) { return str; }
        public static string condi_string(string str) { return str; }

        string x_position, y_position;

        string spd_str = "0000";

        string ltn_stra1 = "00000.0000";
        string ltn_stra2 = "00000.0000";

        string status = "";

        string ltn_stra5 = "    0.000 ";//일의 자리 수일 때         

        char[] x_pos = new char[10];
        char[] y_pos = new char[10];

        double x_start_point;
        double y_start_point;

        double x_stage_point;
        double y_stage_point;

        int x_count;
        int y_count;
        int count_num;


        double x_pitch_size;
        double y_pitch_size;

        private System.Object lockThis = new Object();

        private readonly object thisLock = new object();

        //private System.Object SerialIncoming;

        // = LongTravelStage.CreateLongTravelStage("45877211");

        string open_str = "3,0,0\n";
        string close_str = "1,0,0\n";

        //LongTravelStage long_device;
        LongTravelStage device;
        //string serialNo = "45877211"; 원본//
        string serialNo = "45878910";

        double ma_pos_val;
        double ma_pitch_val;
        double ma_st_val = 300;

        Decimal lts_position1, lts_position2;

        SerialDataReceivedEventArgs serial_e = null;

        string indata = "";
        string indata1 = "";

        int count_y = 0;
        int count_z = 0;

        byte[] Long_stage = new byte[10];
        byte[] Short_stage = new byte[10];

        decimal long_position;

        decimal y_complete;
        decimal x_complete;

        double x_complete_db;
        double y_complete_db;

        double[] long_point = new double[4];
        double[] short_point = new double[2];

        decimal[] z_point = new decimal[3];


        int full_step_count = 3;

        Stopwatch sw = new Stopwatch();

        double mast_wait_posi;

        double shutter_dist;
        int shutter_delay_time = 0;

        decimal posf;
        decimal z_pos;
        decimal z_posision;

        int scan_count_short;


        string serialNo1 = "68250435"; //익산 셔터
        //string serialNo1 = "68250435";

        KCubeSolenoid device1;

        SerialPort _serialPort = new SerialPort();

        public Form1()
        {
            InitializeComponent();

            string[] PortNames = SerialPort.GetPortNames();  // 포트 검색.

            foreach (string portnumber in PortNames)
            {
                comboBox1.Items.Add(portnumber);          // 검색한 포트를 콤보박스에 입력. 
            }
        }

        delegate void MyDelegate_1(Control ctl, string point);
        delegate string MyDelegate_string(string serial);


        public static byte[] Combine(byte[] first, byte[] second) //byte 결합하는 함수에 관한 부분
        {
            return first.Concat(second).ToArray();
        }

        public byte lrc_cal(byte[] data)  //명령어 LRC 계산하는 부분
        {

            //byte XOR 연산
            byte lrc = dummy;

            for (int n = 0; n < data.Length; n++)
            {
                lrc = (byte)(lrc ^ data[n]);
            }
            if (lrc == 0)
            {
                lrc = etx;
            }
            return lrc;
        }


        private void send_function(byte[] msg)
        {
            byte[] bytes = new byte[50];

            byte[] ack = new byte[] { ACK };
            byte[] header = new byte[] { stx, dummy };

            msg = Combine(header, msg);

            if (sock1.Available > 0) // here we clean up the current queue
            {
                sock1.Receive(bytes);
            }

            sock1.Send(msg);

            while (sock1.Available == 0) // wait for the controller response
            {
                Thread.Sleep(100);
            }

            sock1.Receive(bytes); // after receiving the data, we should check the LRC if possible
            string status = Encoding.UTF8.GetString(bytes);

            sock1.Send(ack);
            //msg.Initialize();
        }

        private void send_move(byte[] msg) //좌표 수신 send함수 및 socket
        {

            byte[] bytes = new byte[50];

            byte[] ack = new byte[] { ACK };
            byte[] header = new byte[] { stx, dummy };

            msg = Combine(header, msg);

            if (sock1.Available > 0) // here we clean up the current queue
            {
                sock1.Receive(bytes);
                //sock1.Receive(bytes1);

            }

            sock1.Send(msg);

            while (sock1.Available == 0) // wait for the controller response
            {
                Thread.Sleep(100);
            }

            sock1.Receive(bytes); // after receiving the data, we should check the LRC if possible

            if (bytes.Contains<byte>(nak) || bytes.Contains<byte>(rst) == true)
            {
                sock1.Send(msg);
            }
            else
            {
                sock1.Send(ack);
            }

            status = Encoding.UTF8.GetString(bytes);

            byte[] command = Encoding.UTF8.GetBytes("AC");
            byte[] channel_ba = Encoding.UTF8.GetBytes("0");
            byte[] data_type = Encoding.UTF8.GetBytes("2");
            byte[] make_msg = Combine(command, channel_ba);
            make_msg = Combine(make_msg, data_type);

            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);



            byte[] bytes1 = new byte[50];

            byte[] ack1 = new byte[] { ACK };
            byte[] header1 = new byte[] { stx, dummy };


            make_msg = Combine(header1, make_msg);

            if (sock1.Available > 0) // here we clean up the current queue
            {
                sock1.Receive(bytes1);
            }

            sock1.Send(make_msg);

            while (sock1.Available == 0) // wait for the controller response
            {
                Thread.Sleep(100);
            }

            sock1.Receive(bytes1); // after receiving the data, we should check the LRC if possible

            if (bytes1.Contains<byte>(nak) || bytes1.Contains<byte>(rst) == true)
            {
                sock1.Send(make_msg);
            }
            else
            {
                sock1.Send(ack1);
            }

            status = Encoding.UTF8.GetString(bytes1);

            status.CopyTo(3, x_pos, 0, 10);
            status.CopyTo(13, y_pos, 0, 10);

            int val = Convert.ToInt32(x_pos[8]);
            x_pos[8] = Convert.ToChar(val - 1);

            x_position = new string(x_pos);//비교를 위해 초기값 저장
                                           //x_position = Math.Abs(x_position);

            x_position = x_position.Trim();

            y_position = new string(y_pos);//비교를 위해 초기값 저장
            y_position = y_position.Trim();


            decimal x_st = Convert.ToDecimal(x_stage_point);
            string x_st_fn = x_st.ToString(ltn_stra5);
            x_st_fn = x_st_fn.Trim();

            decimal y_st = Convert.ToDecimal(y_stage_point);
            string y_st_fn = y_st.ToString(ltn_stra5);
            y_st_fn = y_st_fn.Trim();

            while (((x_position.Equals(x_st_fn)) && (y_position.Equals(y_st_fn))) == false)
            {
                sock1.Send(make_msg);

                while (sock1.Available == 0) // wait for the controller response
                {
                    Thread.Sleep(10);
                }

                sock1.Receive(bytes1); // after receiving the data, we should check the LRC if possible

                if (bytes1.Contains<byte>(nak) || bytes1.Contains<byte>(rst) == true)
                {
                    sock1.Send(make_msg);
                }
                else
                {
                    sock1.Send(ack1);
                }
                string status1 = Encoding.UTF8.GetString(bytes1);


                status1.CopyTo(3, x_pos, 0, 10);
                status1.CopyTo(13, y_pos, 0, 10);

                x_position = new string(x_pos); //"  100.000 "
                x_position = x_position.Trim();

                y_position = new string(y_pos);
                y_position = y_position.Trim();

                if (((x_position.Equals(x_st_fn)) && (y_position.Equals(y_st_fn))) == true)
                {
                    break;
                }
            }
            msg.Initialize();
            bytes.Initialize();
        }

        private void send_position(byte[] msg) //좌표 수신
        {

            byte[] bytes = new byte[50];

            byte[] ack = new byte[] { ACK };
            byte[] header = new byte[] { stx, dummy };

            msg = Combine(header, msg);

            if (sock1.Available > 0) // here we clean up the current queue
            {
                sock1.Receive(bytes);
                //sock1.Receive(bytes1);
            }

            sock1.Send(msg);

            while (sock1.Available == 0) // wait for the controller response
            {
                Thread.Sleep(100);
            }

            sock1.Receive(bytes); // after receiving the data, we should check the LRC if possible

            if (bytes.Contains<byte>(nak) || bytes.Contains<byte>(rst) == true)
            {
                sock1.Send(msg);
            }
            else
            {
                sock1.Send(ack);
            }

            status = Encoding.UTF8.GetString(bytes);


            status.CopyTo(3, x_pos, 0, 10);
            status.CopyTo(13, y_pos, 0, 10);

            int val = Convert.ToInt32(x_pos[8]);
            x_pos[8] = Convert.ToChar(48);//Convert.ToChar(val - 1);

            x_position = new string(x_pos);//비교를 위해 초기값 저장
            //x_position = Math.Abs(x_position);
            x_position = x_position.Trim();

            y_position = new string(y_pos);//비교를 위해 초기값 저장
            y_position = y_position.Trim();

            msg.Initialize();
            bytes.Initialize();

            /*
            decimal x_st = Convert.ToDecimal(x_stage_point);
            string x_st_fn = x_st.ToString(ltn_stra5);
            x_st_fn = x_st_fn.Trim();

            decimal y_st = Convert.ToDecimal(y_stage_point);
            string y_st_fn = y_st.ToString(ltn_stra5);
            y_st_fn = y_st_fn.Trim();




            status = Encoding.UTF8.GetString(bytes1);

            status.CopyTo(3, x_pos, 0, 10);
            status.CopyTo(13, y_pos, 0, 10);

            int val = Convert.ToInt32(x_pos[8]);
            x_pos[8] = Convert.ToChar(val - 1);

            x_position = new string(x_pos);//비교를 위해 초기값 저장
                                           //x_position = Math.Abs(x_position);

            x_position = x_position.Trim();

            y_position = new string(y_pos);//비교를 위해 초기값 저장
            y_position = y_position.Trim();


            decimal x_st = Convert.ToDecimal(x_stage_point);
            string x_st_fn = x_st.ToString(ltn_stra5);
            x_st_fn = x_st_fn.Trim();

            decimal y_st = Convert.ToDecimal(y_stage_point);
            string y_st_fn = y_st.ToString(ltn_stra5);
            y_st_fn = y_st_fn.Trim();

            while (((x_position.Equals(x_st_fn)) && (y_position.Equals(y_st_fn))) == false)
            {
                sock1.Send(make_msg);

                while (sock1.Available == 0) // wait for the controller response
                {
                    Thread.Sleep(10);
                }

                sock1.Receive(bytes1); // after receiving the data, we should check the LRC if possible

                if (bytes1.Contains<byte>(nak) || bytes1.Contains<byte>(rst) == true)
                {
                    sock1.Send(make_msg);
                }
                else
                {
                    sock1.Send(ack1);
                }
                string status1 = Encoding.UTF8.GetString(bytes1);


                status1.CopyTo(3, x_pos, 0, 10);
                status1.CopyTo(13, y_pos, 0, 10);

                x_position = new string(x_pos); //"  100.000 "
                x_position = x_position.Trim();

                y_position = new string(y_pos);
                y_position = y_position.Trim();

                if (((x_position.Equals(x_st_fn)) && (y_position.Equals(y_st_fn))) == true)
                {
                    break;
                }
            }
            msg.Initialize();
            bytes.Initialize();
            */
        }

        private void x_position_compare(byte[] msg) //좌표 수신
        {

            byte[] bytes = new byte[30];

            byte[] ack = new byte[] { ACK };
            byte[] header = new byte[] { stx, dummy };

            msg = Combine(header, msg);

            if (sock1.Available > 0) // here we clean up the current queue
            {
                sock1.Receive(bytes);
                //sock1.Receive(bytes1);
            }

            sock1.Send(msg);

            while (sock1.Available == 0) // wait for the controller response
            {
                Thread.Sleep(10);
            }

            sock1.Receive(bytes); // after receiving the data, we should check the LRC if possible

            if (bytes.Contains<byte>(nak) || bytes.Contains<byte>(rst) == true)
            {
                sock1.Send(msg);
            }
            else
            {
                sock1.Send(ack);
            }

            status = Encoding.UTF8.GetString(bytes);


            status.CopyTo(3, x_pos, 0, 7);
            //status.CopyTo(13, y_pos, 0, 10);
            //status.CopyTo(13, y_pos, 0, 7);

            //  000.00000;
            //int val = Convert.ToInt32(x_pos[8]);
            //x_pos[8] = Convert.ToChar(48);//Convert.ToChar(val - 1);

            x_position = new string(x_pos);//비교를 위해 초기값 저장
            x_position = x_position.Trim();

            //x_position = Math.Abs(x_position);


            //y_position = new string(y_pos);//비교를 위해 초기값 저장
            //y_position = y_position.Trim();

            msg.Initialize();
            bytes.Initialize();
            status = "";
        }

        private void y_position_compare(byte[] msg) //좌표 수신
        {

            byte[] bytes = new byte[30];

            byte[] ack = new byte[] { ACK };
            byte[] header = new byte[] { stx, dummy };

            msg = Combine(header, msg);

            if (sock1.Available > 0) // here we clean up the current queue
            {
                sock1.Receive(bytes);
                //sock1.Receive(bytes1);
            }

            sock1.Send(msg);

            while (sock1.Available == 0) // wait for the controller response
            {
                Thread.Sleep(10);
            }

            sock1.Receive(bytes); // after receiving the data, we should check the LRC if possible

            if (bytes.Contains<byte>(nak) || bytes.Contains<byte>(rst) == true)
            {
                sock1.Send(msg);
            }
            else
            {
                sock1.Send(ack);
            }

            status = Encoding.UTF8.GetString(bytes);


            //status.CopyTo(3, x_pos, 0, 10);
            //status.CopyTo(13, y_pos, 0, 10);
            status.CopyTo(13, y_pos, 0, 7);
            //  000.00000;
            //int val = Convert.ToInt32(x_pos[8]);
            //x_pos[8] = Convert.ToChar(48);//Convert.ToChar(val - 1);

            //x_position = new string(x_pos);//비교를 위해 초기값 저장
            //x_position = Math.Abs(x_position);

            //x_position = x_position.Trim();

            y_position = new string(y_pos);//비교를 위해 초기값 저장
            y_position = y_position.Trim();

            msg.Initialize();
            bytes.Initialize();
            status = "";

        }
        private async void Compare_string(double x_string, double y_string)
        {
            decimal x_st = Convert.ToDecimal(x_string);
            string x_st_fn = x_st.ToString(ltn_stra5);
            x_st_fn = x_st_fn.Trim();

            decimal y_st = Convert.ToDecimal(y_string);
            string y_st_fn = y_st.ToString(ltn_stra5);
            y_st_fn = y_st_fn.Trim();

            //int a = Thread.CurrentThread.ManagedThreadId;
            //MTA 1번
            var task1 = Task.Run(() => Check_string(x_st_fn, y_st_fn));
            //int a1 = Thread.CurrentThread.ManagedThreadId;
            task1.Wait();
            //SetText(lb_x_position, x_position);
            //SetText(lb_y_position, y_position);
            await task1;
            //Thread.Sleep(500);
            //System.Action<Task> task2 = System.Action<Task>.Run(() => One_shot(oneshot));
            // await task1.ContinueWith(
            //    antecedent =>
            //    {
            //       serialPort1.Write(oneshot);
            //   },TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        private void Check_string(string x_st_fn, string y_st_fn)
        {
            if (((x_position.Equals(x_st_fn)) && (y_position.Equals(y_st_fn))) == true)
            {
            }
        }
        public void SetText()
        {
            lb_x_position.Text = x_position;
            lb_y_position.Text = y_position;
        }

        private async void Take_oneshot(string oneshot)
        {
            var task1 = Task.Run(() => One_shot(oneshot));

            //SerialDataReceivedEventHandler serialDataReceivedEventHandler = null;
            //serialPort1.DataReceived += serialDataReceivedEventHandler;

            task1.Wait();
            await task1;

            //DataReceiveHandler(serialPort1, serial_e);

        }

        private async void One_shot(string oneshot)
        {
            //SerialDataReceivedEventArgs e = null;   
            //DataReceiveHandler(serialPort1, serial_e);
            serialPort1.Write(oneshot);

            //int a = serialPort1.WriteTimeout;
            //serialDataReceivedEventHandler
            //serialPort1.DataReceived serialDataReceivedEventHandler; += serialDataReceivedEventHandler

            //task1.Wait();
            //await task1;
        }

        public byte[] rebot_contr()
        {
            byte[] command = Encoding.UTF8.GetBytes("CJ");

            byte lrc = lrc_cal(command);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            command = Combine(command, etx_ba);
            command = Combine(command, lrc_ba);

            return command;
        }


        public byte[] jog_move(string channel, string axis, string pm)//jog move 함수
        {
            byte[] command = Encoding.UTF8.GetBytes("BE");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] axis_type = Encoding.UTF8.GetBytes(axis);
            byte[] direc_type = Encoding.UTF8.GetBytes(pm);
            byte[] motion_type = Encoding.UTF8.GetBytes("0");
            byte[] make_msg = Combine(command, channel_ba);
            make_msg = Combine(make_msg, axis_type);
            make_msg = Combine(make_msg, direc_type);
            make_msg = Combine(make_msg, motion_type);

            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }

        public byte[] move_zero(string channel) // 원점 이동 부분
        {
            byte[] command = Encoding.UTF8.GetBytes("BA");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] make_msg = Combine(command, channel_ba);

            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }

        public byte[] error_chk() //error chk
        {
            byte[] make_msg = Encoding.UTF8.GetBytes("KD");

            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }

        public byte[] posi_check_robot(string channel) //robot_position chk
        {
            byte[] command = Encoding.UTF8.GetBytes("AC");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] data_type = Encoding.UTF8.GetBytes("2");
            byte[] make_msg = Combine(command, channel_ba);
            make_msg = Combine(make_msg, data_type);

            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }

        public byte[] move_continue(string channel) //Jog무브 간에 연속 구동 신호 전송 함수
        {
            byte[] command = Encoding.UTF8.GetBytes("BF");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);

            byte[] make_msg = Combine(command, channel_ba);

            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }

        public byte[] move_stop_func(string channel) //스테이지 비상정지 함수
        {
            byte[] command = Encoding.UTF8.GetBytes("BG");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] make_msg = Combine(command, channel_ba);

            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }

        public byte[] servo_on(string channel)
        {
            byte[] command = Encoding.UTF8.GetBytes("DB");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] data_type = Encoding.UTF8.GetBytes("1");
            byte[] make_msg = Combine(command, channel_ba);
            make_msg = Combine(make_msg, data_type);

            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }

        public byte[] servo_off(string channel)
        {
            byte[] command = Encoding.UTF8.GetBytes("DB");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] data_type = Encoding.UTF8.GetBytes("0");
            byte[] make_msg = Combine(command, channel_ba);
            make_msg = Combine(make_msg, data_type);

            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }

        public byte[] speed(string channel, string spd)
        {
            byte[] command = Encoding.UTF8.GetBytes("CB");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] speed_set = Encoding.UTF8.GetBytes(spd);
            byte[] make_msg = Combine(command, channel_ba);
            make_msg = Combine(make_msg, speed_set);

            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }


        public byte[] error_re()
        {
            byte[] command = Encoding.UTF8.GetBytes("CG");

            byte lrc = lrc_cal(command);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            command = Combine(command, etx_ba);
            command = Combine(command, lrc_ba);

            return command;
        }

        public void move_start_point(double x, double y)
        {
            var comm = move_axis("0", x, y);
            send_move(comm);
        }

        private void origin_Click(object sender, EventArgs e)
        {

            //Move_Method1(device, 150);

            var comm = move_zero("0");
            send_function(comm);
        }

        private void start_point_Click(object sender, EventArgs e)
        {
            x_stage_point = Convert.ToDouble(str_pt_x.Value);
            y_stage_point = Convert.ToDouble(str_pt_y.Value);

            move_start_point(x_stage_point, y_stage_point);
        }

        private void sv_on_Click(object sender, EventArgs e)
        {
            var comm = servo_on("0");
            send_function(comm);
        }

        private void sv_off_Click(object sender, EventArgs e)
        {
            var comm = servo_off("0");
            send_function(comm);
        }

        private void errorchk_Click(object sender, EventArgs e)
        {
            var comm = error_chk();
            send_function(comm);
        }

        private void spd_set_Click(object sender, EventArgs e)
        {
            decimal speed_1 = short_spd.Value;
            string spd = speed_1.ToString(spd_str);
            var comm = speed("0", spd);
            send_function(comm);

            decimal velocity = z_stg_spd.Value;
            VelocityParameters velPars = device.GetVelocityParams();
            velPars.MaxVelocity = velocity;
            device.SetVelocityParams(velPars);


        }

        private void stg_con_Click(object sender, EventArgs e)
        {

            sock1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip1 = IPAddress.Parse("192.168.1.203");//인자값 : 서버측 IP         
            IPEndPoint endPoint1 = new IPEndPoint(ip1, 20000);//인자값 : IPAddress,포트번호

            while (sock1.Connected == false)
            {
                sock1.Connect(endPoint1);
            }

            decimal position = 0;
            decimal velocity = 10;

            //string path = @"bin\x64\Debug\LTS_serial.txt";
            string[] lines =
            {
                "First line"
            };

            File.WriteAllLines("LTS_serial.txt", lines);



            try
            {
                // Tell the device manager to get the list of all devices connected to the computer
                DeviceManagerCLI.BuildDeviceList();
            }
            catch (Exception ex)
            {
                // An error occurred - see ex for details
                Console.WriteLine("Exception raised by BuildDeviceList {0}", ex);
                //Console.ReadKey();
                return;
            }

            // Get available Long Stage Travel and check our serial number is correct
            // (i.e. for serial number 45000123, the device prefix is 45)

            List<string> serialNumbers = DeviceManagerCLI.GetDeviceList(LongTravelStage.DevicePrefix);

            device = LongTravelStage.CreateLongTravelStage(serialNo);
            // Create the device - LTS
            //LongTravelStage device = LongTravelStage.CreateLongTravelStage(serialNo);
            if (device == null)
            {
                // An error occured
                Console.WriteLine("{0} is not a LongStageTravel", serialNo);
                //Console.ReadKey();
                return;
            }

            // Open a connection to the device.
            Console.WriteLine("Opening device {0}", serialNo);
            try
            {
                device.Connect(serialNo);
            }
            catch (Exception)
            {
                // Connection failed
                Console.WriteLine("Failed to open device {0}", serialNo);
                //Console.ReadKey();
                return;
            }

            // Wait for the device settings to initialize - timeout 5000ms
            if (!device.IsSettingsInitialized())
            {
                try
                {
                    device.WaitForSettingsInitialized(5000);
                }
                catch (Exception)
                {
                    Console.WriteLine("Settings failed to initialize");
                }
            }

            // Start the device polling
            // The polling loop requests regular status requests to the motor to ensure the program keeps track of the device. 
            device.StartPolling(250);
            // Needs a delay so that the current enabled state can be obtained
            Thread.Sleep(500);
            // Enable the channel otherwise any move is ignored 
            device.EnableDevice();
            // Needs a delay to give time for the device to be enabled
            Thread.Sleep(500);

            // Call LoadMotorConfiguration on the device to initialize the DeviceUnitConverter object required for real world unit parameters
            //  - loads configuration information into channel
            MotorConfiguration motorConfiguration = device.LoadMotorConfiguration(serialNo);

            // Display info about device
            DeviceInfo deviceInfo = device.GetDeviceInfo();
            Console.WriteLine("Device {0} = {1}", deviceInfo.SerialNumber, deviceInfo.Name);

            bool homed = device.Status.IsHomed;

            // If a position is requested
            if (position != 0)
            {
                // Update velocity if required using real world methods
                if (velocity != 0)
                {
                    VelocityParameters velPars = device.GetVelocityParams();
                    velPars.MaxVelocity = velocity;
                    device.SetVelocityParams(velPars);
                }

                //device.Home(0);
                //Move_Method1(device, position);
                // or
                // Move_Method2(device, position);

                Decimal newPos = device.Position;
            }

            if (sock1.Connected && device.IsConnected == true)
            {
                textBox1.Text = ("XY, Z Stage Connected");
                stg_con.Enabled = false;
            }
        }

        private void stg_dis_Click(object sender, EventArgs e)
        {
            sock1.Close();
            textBox1.Text = ("Stage Disconnected");

            Move_Method1(device, 10);


            if (device == null)
            {
                MessageBox.Show("Not connected to device");
                return;
            }

            // All of this operation has been placed inside a "catch-all" exception
            // handler. Normally you would catch the more specific exceptions that
            // the API call might throw (details of which can be found in the
            // Kinesis .NET API document).
            try
            {
                // Shuts down this device and frees any resources it is using.
                device.ShutDown();

                device = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to disconnect from device\n" + ex);
            }

            if (device == null && sock1.Connected == false)
            {
                stg_con.Enabled = true;
            }

        }

        //*********************************   Shutter   ***********************************************************************
        //*****************************************************************************************************************

        private void Open_btn_Click(object sender, EventArgs e)
        {
            int Timeout = Convert.ToInt32(exposure_time.Value);

            if (serialPort1.IsOpen == false)
            {
                serialPort1.PortName = Port_Combox.SelectedItem.ToString();                     //콤보 박스에서 선택.
                serialPort1.BaudRate = int.Parse(Baud_Combox.SelectedItem.ToString());          //콤보 박스에서 Baud Rate 선택.
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;

                serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceiveHandler);

                serialPort1.Open();

                //serialPort1.WriteLine("abcd\r\n");  // abcd\r\n Send

                //if (WaitForAData(Timeout))
                //  Console.WriteLine("Okay in TestFunc");
                //else
                //  Console.WriteLine("Time out in TestFunc");

                if (serialPort1.IsOpen == true)
                {
                    Open_btn.Enabled = false;
                }
            }
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Write("1,0,0\n");
                serialPort1.Close();

                Open_btn.Enabled = true;

            }
        }

        private void button_shutter_open_Click(object sender, EventArgs e)
        {
            string open_str = "3,0,0\n";
            serialPort1.Write(open_str);




        }

        private void button_shutter_close_Click(object sender, EventArgs e)
        {
            string close_str = "1,0,0\n";
            serialPort1.WriteLine(close_str);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oneshot = "4," + exposure_time.Value.ToString() + ",0,\n";
            serialPort1.Write(oneshot);
        }


        //************************************************************************************************************
        //************************************************************************************************************


        public byte[] move_axis(string channel, double x_axis_point, double y_axis_point)
        {
            byte[] command = Encoding.UTF8.GetBytes("BC"); //Controller 명령어 입력
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] motion_type = Encoding.UTF8.GetBytes("0");
            byte[] xy_type = Encoding.UTF8.GetBytes("1");

            decimal long_st1 = Convert.ToDecimal(x_axis_point);
            string long_st_fn = long_st1.ToString(ltn_stra2);

            decimal null_byte = 0;
            string null_st_fn = null_byte.ToString(ltn_stra2);

            decimal short_st1 = Convert.ToDecimal(y_axis_point);
            string short_st_fn = short_st1.ToString(ltn_stra2);

            byte[] xy_location1 = Encoding.UTF8.GetBytes(long_st_fn);
            byte[] xy_location_null = Encoding.UTF8.GetBytes(null_st_fn);

            byte[] xy_location2 = Encoding.UTF8.GetBytes(short_st_fn);
            byte[] xy_location_null2 = Encoding.UTF8.GetBytes(short_st_fn);

            // byte[] xy_location_final = Combine(xy_location1, xy_location2);

            byte[] xy_location_final = Combine(xy_location1, xy_location_null);
            xy_location_final = Combine(xy_location_final, xy_location2);
            xy_location_final = Combine(xy_location_final, xy_location_null2);//목표 위치 (x,y) 좌표 입력

            byte[] make_msg = Combine(command, channel_ba);//Controller 프로토콜에 따른 형식 맞춤 영역
            make_msg = Combine(make_msg, motion_type);
            make_msg = Combine(make_msg, xy_type);
            make_msg = Combine(make_msg, xy_location_final);

            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;//완성된 명령문 리턴
        }





        public double y_down_move(double previous_y)
        {
            double y_move_down = Convert.ToDouble(previous_y) + y_pitch_size;
            return y_move_down;
        }

        public double x_right_move(double previous_x)
        {

            double x_move_right = Convert.ToDouble(previous_x) + x_pitch_size;
            return x_move_right;
        }

        public double x_left_move(double previous_x)
        {
            double x_move_left = Convert.ToDouble(previous_x) - x_pitch_size;
            return x_move_left;
        }


        private async void DataReceiveHandler(object sender, SerialDataReceivedEventArgs serial_e)
        {
            SerialPort sp = (SerialPort)sender;
            indata = sp.ReadExisting();

            var task1 = Task.Run(() =>
            {
                lock (lockThis)
                {
                    Monitor.Pulse(lockThis);

                    if (indata == "Done\r\n")
                    {
                        //indata1 = indata;
                        //Monitor.Exit(lockThis);
                    }
                }
            });
            task1.Wait();
            await task1;
            indata = "";
        }


        public bool WaitForAData(int Timeout)
        {
            lock (lockThis)//waits N seconds for a condition variable
            {
                if (!Monitor.Wait(lockThis, Timeout))
                {//if timeout
                    Console.WriteLine("Time out");
                    return false;
                }
                return true;
            }
        }

        private async void stage_move_Click(object sender, EventArgs e)
        {
            /*
            decimal x_axis_pt_a1 = str_pt_x.Value;
            decimal y_axis_pt_a1 = str_pt_y.Value;

            string point_a1 = x_axis_pt_a1.ToString(ltn_stra1);
            string point_a2 = y_axis_pt_a1.ToString(ltn_stra2);

            x_start_point = Convert.ToDouble(str_pt_x.Value);//전역
            y_start_point = Convert.ToDouble(str_pt_y.Value);//전역

            x_stage_point = Convert.ToDouble(str_pt_x.Value);//전역
            y_stage_point = Convert.ToDouble(str_pt_y.Value);//전역

            x_count = Convert.ToInt32(x_array.Value);//전역
            y_count = Convert.ToInt32(y_array.Value);//전역

            x_pitch_size = Convert.ToDouble(pitch_val_x.Value);//전역
            y_pitch_size = Convert.ToDouble(pitch_val_y.Value);//전역

            //double pitch_size = Convert.ToDouble(pitch_val_x.Value);
            //double pitch_size2 = Convert.ToDouble(pitch_val_y.Value);

            //string spd = mtr_spd.Value.ToString();

            //int stage_del = Convert.ToInt32(delay_time.Value);
            //stage_del = (stage_del * 1000) + 1000;

            string oneshot = "4," + exposure_time.Value.ToString() + ",0,\n";
            int shutt_del = Convert.ToInt32(exposure_time.Value);
            shutt_del = (shutt_del * 1000) + 1000;

            double x_limt = x_start_point + (x_pitch_size * (x_count - 1));
            double y_limt = y_start_point + (y_pitch_size * (y_count - 1));

            if (y_limt > 451)//y 센서 거리 초과
            {
                var comm = move_axis("0", x_stage_point, y_stage_point);
                send_move(comm);
                textBox1.Text = ("OVER Y-AXIS LIMIT");
            }

            else if (x_limt > 801)//x 센서 거리 초과
            {
                var comm = move_axis("0", x_stage_point, y_stage_point);
                send_move(comm);
                textBox1.Text = ("OVER X-AXIS LIMIT");
            }


            else if (x_count == 1 && y_count == 1)// (x, y), (1,1) 스타트 포인트
            {
                var comm = move_axis("0", x_stage_point, y_stage_point);
                send_move(comm);
                // Thread.Sleep(4000);
                // serialPort1.Write(oneshot);
                // Thread.Sleep(shutt_del);
            }

            else if (x_count > 1 && y_count > 1)
            {   //(x, y) -> (n, m) 부분
                //100 mm/s

                //for (int i = 0; i < imageFileList_Load.Count(); i++)
                //{
                //Console.WriteLine("arr[" + i + "] : " + imageFileList_Load[i]);
                //mats[i] = Cv2.ImRead(imageFileList_Load[i]);
                //Cv2.ImShow("{ 0 }" + i, mats[i]);
                //Cv2.WaitKey(100);
                //}

                // Cv2.ImShow("test", mats[0]);
                // Cv2.WaitKey(shutt_del);
                // count++;

                var comm = move_axis("0", x_stage_point, y_stage_point);
                send_move(comm);
                Compare_string(x_stage_point, y_stage_point);
                await Task.Run(() => SetText());
                Thread.Sleep(1000);

                decimal posf = move_up(ma_pos_val);
                Move_Method1(device, posf);

                await Task.Run(() => Take_oneshot(oneshot));
                DataReceiveHandler(serialPort1, serial_e);
                Thread.Sleep(shutt_del);

                posf = move_down(ma_pos_val);
                Move_Method1(device, posf);                       

                for (int i = 1; i < y_count + 1; i++) //y가 1씩 증가할때
                {
                    if (i % 2 == 0) //y카운트 짝수일 때
                    {
                        for (int r = 1; r < x_count; r++)
                        {
                            // Cv2.ImShow("test", mats[count]);
                            // Cv2.WaitKey(shutt_del);
                            // count++;

                            x_stage_point = x_left_move(x_stage_point);
                            comm = move_axis("0", x_stage_point, y_stage_point);

                            send_move(comm);

                            Compare_string(x_stage_point, y_stage_point);
                            await Task.Run(() => SetText());
                            Thread.Sleep(1000);

                            posf = move_up(ma_pos_val);
                            Move_Method1(device, posf);

                            await Task.Run(() => Take_oneshot(oneshot));
                            DataReceiveHandler(serialPort1, serial_e);
                            Thread.Sleep(shutt_del);

                            posf = move_down(ma_pos_val);
                            Move_Method1(device, posf);                           

                            double tmp1 = r * i;

                            if (tmp1 == (x_count - 1) * y_count)
                            {
                                break;
                            }
                            else if (r == x_count - 1)
                            {
                                //  Cv2.ImShow("test", mats[count]);
                                // Cv2.WaitKey(shutt_del);
                                //count++;

                                y_stage_point = y_down_move(y_stage_point);
                                comm = move_axis("0", x_stage_point, y_stage_point);
                                send_move(comm);
                                Compare_string(x_stage_point, y_stage_point);
                                await Task.Run(() => SetText());
                                Thread.Sleep(1000);

                                posf = move_up(ma_pos_val);
                                Move_Method1(device, posf);

                                await Task.Run(() => Take_oneshot(oneshot));
                                DataReceiveHandler(serialPort1, serial_e);
                                Thread.Sleep(shutt_del);

                                posf = move_down(ma_pos_val);
                                Move_Method1(device, posf);
                            }
                        }
                    }
                    else
                    {
                        for (int m = 1; m < x_count; m++)//y카운트 홀수일 때
                        {
                            // Cv2.ImShow("test", mats[count]);
                            // Cv2.WaitKey(shutt_del);
                            // count++;

                            x_stage_point = x_right_move(x_stage_point);
                            comm = move_axis("0", x_stage_point, y_stage_point);
                            send_move(comm);
                            Compare_string(x_stage_point, y_stage_point);
                            await Task.Run(() => SetText());
                            Thread.Sleep(1000);

                            posf = move_up(ma_pos_val);
                            Move_Method1(device, posf);

                            await Task.Run(() => Take_oneshot(oneshot));
                            DataReceiveHandler(serialPort1, serial_e);
                            Thread.Sleep(shutt_del);

                            posf = move_down(ma_pos_val);
                            Move_Method1(device, posf);

                            // Thread.Sleep(stage_del);
                            // serialPort1.Write(oneshot);
                            // Thread.Sleep(shutt_del);

                            double tmp2 = m * i;

                            if (tmp2 == (x_count - 1) * y_count)
                            {
                                break;
                            }
                            else if (m == x_count - 1)
                            {
                                // Cv2.ImShow("test", mats[count]);
                                // Cv2.WaitKey(shutt_del);
                                // count++;

                                y_stage_point = y_down_move(y_stage_point);
                                comm = move_axis("0", x_stage_point, y_stage_point);
                                send_move(comm);
                                Compare_string(x_stage_point, y_stage_point);
                                //await Task.Run(() => SetText());
                                Thread.Sleep(1000);

                                posf = move_up(ma_pos_val);
                                Move_Method1(device, posf);

                                await Task.Run(() => Take_oneshot(oneshot));
                                DataReceiveHandler(serialPort1, serial_e);
                                Thread.Sleep(shutt_del);

                                posf = move_down(ma_pos_val);
                                Move_Method1(device, posf);

                                //Thread.Sleep(stage_del);
                                //serialPort1.Write(oneshot);
                                //Thread.Sleep(shutt_del);
                            }
                        }
                    }
                }

                x_stage_point = x_start_point;
                y_stage_point = y_start_point;
                comm = move_axis("0", x_stage_point, y_stage_point);
                send_move(comm);
                Compare_string(y_stage_point, y_stage_point);
                await Task.Run(() => SetText());
                Thread.Sleep(1000);

                //Take_oneshot(oneshot);
                //serialPort1.Write(close_sut);
                //Cv2.DestroyWindow("test");
                //mats.Initialize();
                //}
                
            }*/
        }



        // ***********************************  LTS_Control  *************************************************


        public static void Move_Method1(IGenericAdvancedMotor device, decimal position) //LTS 포인트 이동 함수
        {
            try
            {
                Console.WriteLine("Moving Device to {0}", position);
                device.MoveTo(position, 60000);
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to move to position");
                //Console.ReadKey();
                return;
            }
            Console.WriteLine("Device Moved");
        }



        public decimal move_front(double present)//LTS 파라미터 만큼 전진 함수
        {

            ma_pitch_val = Convert.ToDouble(mast_pitch.Value);
            ma_pos_val = ma_pos_val + ma_pitch_val;
            string pos_s = Convert.ToString(ma_pos_val);
            Decimal posf = Convert.ToDecimal(pos_s);
            return posf;
        }

        public decimal move_back(double present)//LTS 파라미터 만큼 후진하는 함수
        {
            ma_pitch_val = Convert.ToDouble(mast_pitch.Value);
            ma_pos_val = ma_pos_val + ma_pitch_val;
            string pos_s = Convert.ToString(ma_pos_val);
            Decimal posf = Convert.ToDecimal(pos_s);
            return posf;
        }

        public decimal move_back_val(decimal present)
        {


            //ma_pitch_val = Convert.ToDouble(mast_pitch.Value);
            //ma_pitch_val = Convert.ToDouble(z_pitch.Value);
            decimal z_pitch_val = z_pitch.Value;
            present = present - z_pitch_val;

            //string pos_s = Convert.ToString(present);
            //Decimal posf = Convert.ToDecimal(pos_s);
            //Decimal z_back = Convert.ToDecimal(pos_s);

            return present;
        }





        private void mast_st_pnt_Click(object sender, EventArgs e)
        {
            double st = Convert.ToDouble(mast_start.Value);

            ma_pos_val = 300 - st;
            string pos_s = Convert.ToString(ma_pos_val);
            decimal posf = Convert.ToDecimal(pos_s);
            Move_Method1(device, posf);
        }





        private void lts_disscon_Click(object sender, EventArgs e)
        {

            Move_Method1(device, 10);


            if (device == null)
            {
                MessageBox.Show("Not connected to device");
                return;
            }

            // All of this operation has been placed inside a "catch-all" exception
            // handler. Normally you would catch the more specific exceptions that
            // the API call might throw (details of which can be found in the
            // Kinesis .NET API document).
            try
            {
                // Shuts down this device and frees any resources it is using.
                device.ShutDown();

                device = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to disconnect from device\n" + ex);
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Move_Method1(device, 200);

            if (device == null)
            {
                //MessageBox.Show("Not connected to device");
                return;
            }

            // All of this operation has been placed inside a "catch-all" exception
            // handler. Normally you would catch the more specific exceptions that
            // the API call might throw (details of which can be found in the
            // Kinesis .NET API document).
            try
            {
                // Shuts down this device and frees any resources it is using.
                device.ShutDown();

                device = null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Unable to disconnect from device\n" + ex);
            }
        }


        private void posi_chk_Click(object sender, EventArgs e)
        {

            var comm = posi_check_robot("0");
            send_position(comm);
            // Compare_string(x_stage_point, y_stage_point);
            //Task.Run(() => SetText());
            this.Invoke(new Action(SetText));

        }

        private void rebot_controller_Click(object sender, EventArgs e)
        {
            var comm1 = rebot_contr();
            send_function(comm1);

        }
        public byte[] Error_reset(string channel)
        {
            byte[] make_msg = Encoding.UTF8.GetBytes("CG");
            byte lrc = lrc_cal(make_msg);
            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };
            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);
            return make_msg;
        }

        private void error_reset_Click(object sender, EventArgs e)
        {
            var comm = Error_reset("0");
            send_function(comm);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            // All of this operation has been placed inside a "catch-all" exception
            // handler. Normally you would catch the more specific exceptions that
            // the API call might throw (details of which can be found in the
            // Kinesis .NET API document).
            try
            {
                // We ask the device to throw an exception if the operation takes
                // longer than 1000ms (1s).
                device.Stop(1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to stop\n" + ex);
            }
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonHome_Click(object sender, EventArgs e)
        {

            try
            {
                // We pass in a wait timeout of zero to indicates we don't care how
                // long it takes to perform the home operation.
                device.Home(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to return device to home position\n" + ex);
            }

        }

        private void pitch_move_Click(object sender, EventArgs e)
        {
            decimal posf;
            decimal velocity = z_stg_spd.Value;

            VelocityParameters velPars = device.GetVelocityParams();
            velPars.MaxVelocity = velocity;
            device.SetVelocityParams(velPars);

            double st = Convert.ToDouble(mast_start.Value);

            // ma_pos_val = 300 - st;




            if (count_z % 2 == 0)
            {
                posf = move_front(ma_pos_val);// 2번 z stg 앞 이동
                Move_Method1(device, posf);

            }
            else
            {
                posf = move_back(ma_pos_val); // 7번 z stg 대기 위치 (-5mm)
                Move_Method1(device, posf);

            }

            count_z++;




        }


        private async void z_start_point_Click(object sender, EventArgs e)
        {

            decimal velocity = z_stg_spd.Value;

            VelocityParameters velPars = device.GetVelocityParams();
            velPars.MaxVelocity = velocity;
            device.SetVelocityParams(velPars);



            double st = Convert.ToDouble(mast_start.Value);

            ma_pos_val = 300 - st;
            string pos_s = Convert.ToString(ma_pos_val);
            decimal posf = Convert.ToDecimal(pos_s);


            var task1 = Task.Run(() =>
            {
                //var comm = move_axis("0", x_stage_point, y_stage_point);
                //send_move(comm);
                //Task.WhenAny(Task.Run(() => Compare_string(x_stage_point, y_stage_point)));                    
                //Compare_string(x_stage_point, y_stage_point);

                Move_Method1(device, posf);

            });
            await task1;





        }









        private async void y_up_Click(object sender, EventArgs e)
        {
            decimal speed_1 = short_spd.Value; //단축 left
            string spd = speed_1.ToString(spd_str);
            var comm_spd = speed("0", spd);
            send_function(comm_spd);

            Thread.Sleep(500);

            var task1 = Task.Run(() =>
            {
                var comm = jog_start("0", "1", "0");
                send_function(comm);
            });
            await task1;
        }

        private async void y_down_Click(object sender, EventArgs e)
        {
            decimal speed_1 = short_spd.Value;
            string spd = speed_1.ToString(spd_str);
            var comm_spd = speed("0", spd);
            send_function(comm_spd);

            Thread.Sleep(500);

            var comm = jog_start("0", "1", "1");
            send_function(comm);

        }

        private async void x_left_Click(object sender, EventArgs e)
        {
            decimal speed_1 = short_spd.Value;
            string spd = speed_1.ToString(spd_str);
            var comm_spd = speed("0", spd);
            send_function(comm_spd);

            Thread.Sleep(500);

            var comm = jog_start("0", "0", "0");
            send_function(comm);


        }

        private async void x_right_Click(object sender, EventArgs e)
        {
            decimal speed_1 = short_spd.Value;
            string spd = speed_1.ToString(spd_str);
            var comm_spd = speed("0", spd);
            send_function(comm_spd);

            Thread.Sleep(500);

            var comm = jog_start("0", "0", "1");
            send_function(comm);

        }

        public byte[] jog_start(string channel, string axis, string pm)
        {
            byte[] command = Encoding.UTF8.GetBytes("BE");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] axis_type = Encoding.UTF8.GetBytes(axis);
            byte[] direc_type = Encoding.UTF8.GetBytes(pm);
            byte[] motion_type = Encoding.UTF8.GetBytes("0");
            byte[] make_msg = Combine(command, channel_ba);
            make_msg = Combine(make_msg, axis_type);
            make_msg = Combine(make_msg, direc_type);
            make_msg = Combine(make_msg, motion_type);


            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }

        public byte[] move_axis_all(string channel, double x_axis_point, double y_axis_point)
        {
            byte[] command = Encoding.UTF8.GetBytes("BC");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] motion_type = Encoding.UTF8.GetBytes("0");
            byte[] xy_type = Encoding.UTF8.GetBytes("1");

            //decimal long_st1 = Convert.ToDecimal(x_axis_point);
            //decimal long_st1 = Convert.ToDecimal(162);
            //string long_st_fn = long_st1.ToString(ltn_stra2);


            decimal null_byte = 0;

            decimal short_st1 = Convert.ToDecimal(y_axis_point);
            string short_st_fn = short_st1.ToString(ltn_stra2);

            decimal long_st1 = Convert.ToDecimal(x_axis_point);
            string long_st_fn = long_st1.ToString(ltn_stra2);

            byte[] xy_location1 = Encoding.UTF8.GetBytes(long_st_fn);
            //byte[] xy_location_null = Encoding.UTF8.GetBytes(null_st_fn);

            byte[] xy_location2 = Encoding.UTF8.GetBytes(short_st_fn);
            //byte[] xy_location_null2 = Encoding.UTF8.GetBytes(short_st_fn);

            Short_stage = xy_location2;
            Long_stage = xy_location1;

            //byte[] xy_location_final = Combine(xy_location1, xy_location_null);
            //xy_location_final = Combine(xy_location_final, xy_location2);
            //xy_location_final = Combine(xy_location_final, xy_location_null2);

            //Long_stage = Long_point1.Value;
            string null_st_fn = Long_point1.Value.ToString(ltn_stra2);

            byte[] xy_location_final = Combine(xy_location1, xy_location2);

            //xy_location_null = Long_stage;

            byte[] make_msg = Combine(command, channel_ba);
            make_msg = Combine(make_msg, motion_type);
            make_msg = Combine(make_msg, xy_type);
            make_msg = Combine(make_msg, xy_location_final);

            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }

        public byte[] move_axis_x(string channel, double x_axis_point)
        {
            byte[] command = Encoding.UTF8.GetBytes("BC");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] motion_type = Encoding.UTF8.GetBytes("0");
            byte[] xy_type = Encoding.UTF8.GetBytes("1");

            decimal long_st1 = Convert.ToDecimal(x_axis_point);
            string long_st_fn = long_st1.ToString(ltn_stra2);

            decimal null_byte = 0;
            string null_st_fn = null_byte.ToString(ltn_stra2);

            //decimal short_st1 = Convert.ToDecimal(y_axis_point);
            //string short_st_fn = short_st1.ToString(ltn_stra2);

            byte[] xy_location1 = Encoding.UTF8.GetBytes(long_st_fn);
            byte[] xy_location_null = Encoding.UTF8.GetBytes(null_st_fn);

            int a = xy_location1.Length;

            Long_stage = xy_location1;

            //byte[] xy_location2 = Encoding.UTF8.GetBytes(short_st_fn);
            //byte[] xy_location_null2 = Encoding.UTF8.GetBytes(short_st_fn);

            byte[] xy_location_final = Combine(xy_location1, Short_stage);
            //xy_location_final = Combine(xy_location_final, xy_location2);
            //xy_location_final = Combine(xy_location_final, xy_location_null);

            //byte[] xy_location_final = Combine(xy_location1, xy_location_null);

            byte[] make_msg = Combine(command, channel_ba);
            make_msg = Combine(make_msg, motion_type);
            make_msg = Combine(make_msg, xy_type);
            make_msg = Combine(make_msg, xy_location_final);

            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }


        public byte[] move_axis_y(string channel, double y_axis_point)
        {
            byte[] command = Encoding.UTF8.GetBytes("BC");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] motion_type = Encoding.UTF8.GetBytes("0");
            byte[] xy_type = Encoding.UTF8.GetBytes("1");

            //decimal long_st1 = Convert.ToDecimal(x_axis_point);
            //decimal long_st1 = Convert.ToDecimal(162);
            //string long_st_fn = long_st1.ToString(ltn_stra2);


            decimal null_byte = 0;

            decimal short_st1 = Convert.ToDecimal(y_axis_point);
            string short_st_fn = short_st1.ToString(ltn_stra2);

            //byte[] xy_location1 = Encoding.UTF8.GetBytes(long_st1);
            //byte[] xy_location_null = Encoding.UTF8.GetBytes(null_st_fn);

            byte[] xy_location2 = Encoding.UTF8.GetBytes(short_st_fn);
            //byte[] xy_location_null2 = Encoding.UTF8.GetBytes(short_st_fn);

            Short_stage = xy_location2;

            //byte[] xy_location_final = Combine(xy_location1, xy_location_null);
            //xy_location_final = Combine(xy_location_final, xy_location2);
            //xy_location_final = Combine(xy_location_final, xy_location_null2);

            //Long_stage = Long_point1.Value;
            string null_st_fn = Long_point1.Value.ToString(ltn_stra2);

            byte[] xy_location_final = Combine(Long_stage, xy_location2);

            //xy_location_null = Long_stage;

            byte[] make_msg = Combine(command, channel_ba);
            make_msg = Combine(make_msg, motion_type);
            make_msg = Combine(make_msg, xy_type);
            make_msg = Combine(make_msg, xy_location_final);

            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }



        public double long_move(double previous_x)
        {
            //0 + x_pitch mm
            double x_move_left = Convert.ToDouble(previous_x);

            return x_move_left;
        }

        private void long_stage_Click(object sender, EventArgs e)
        {
            decimal speed_1 = long_spd.Value;
            string spd = speed_1.ToString(spd_str);
            var comm_spd = speed("0", spd);
            send_function(comm_spd);

            Thread.Sleep(500);

            x_pitch_size = Convert.ToDouble(pitch_val_x.Value);//전역

            decimal x_axis_pt_a1 = str_pt_x.Value;
            string point_a1 = x_axis_pt_a1.ToString(ltn_stra1);

            x_start_point = Convert.ToDouble(str_pt_x.Value);//전역

            //x_stage_point = 0;
            //x_stage_point = Convert.ToDouble(str_pt_x.Value);//전역

            x_stage_point = long_move(x_start_point);

            var comm = move_axis_x("0", x_stage_point);
            send_function(comm);
            //x_count = Convert.ToInt32(x_array.Value);//전역
            //y_count = Convert.ToInt32(y_array.Value);//전역
        }

        public double short_move(double previous_y)
        {
            double y_move_left = 0;

            if (count_y % 2 == 0)
            {
                y_move_left = Convert.ToDouble(previous_y) + y_pitch_size;
            }
            else
            {
                y_move_left = Convert.ToDouble(previous_y) - y_pitch_size;
            }
            count_y++;

            return y_move_left;
        }



        private void short_stage_Click(object sender, EventArgs e)
        {

            decimal speed_1 = short_spd.Value;
            string spd = speed_1.ToString(spd_str);
            var comm_spd = speed("0", spd);
            send_function(comm_spd);
            Thread.Sleep(500);

            y_pitch_size = Convert.ToDouble(short_point_end.Value);//전역

            decimal y_axis_pt_a1 = short_point_0.Value;
            string point_a2 = y_axis_pt_a1.ToString(ltn_stra2);

            //y_start_point = Convert.ToDouble(short_point_0.Value);//전역
            //str_pt_y
            y_start_point = Convert.ToDouble(str_pt_y.Value);//전역

            //y_stage_point = 0;//전역
            //y_stage_point = short_move(y_stage_point);

            var comm = move_axis_y("0", y_start_point);
            send_function(comm);

            //if(scan_count == 2)
            //{
            //    var comm_1 = move_axis_y("0", y_start_point);
            //    send_function(comm_1);
            //}



        }





        public double long_point_setting(int long_count) // X 스테이지 포인트 설정 함수
        {
            //int i = 0;
            //double y_move_left = 0;
            long_point[0] = Convert.ToDouble(Long_point1.Value); //150
            long_point[1] = Convert.ToDouble(Long_point2.Value); //450
            long_point[2] = Convert.ToDouble(Long_point3.Value); //750
            long_point[3] = Convert.ToDouble(Long_point4.Value);

            switch (long_count)
            {
                case 1:
                    x_stage_point = long_point[0];
                    break;
                case 2:
                    x_stage_point = long_point[1];
                    break;
                case 3:
                    x_stage_point = long_point[2];
                    break;
                case 4:
                    x_stage_point = long_point[3];
                    break;
            }
            return x_stage_point;
        }
        public double short_point_setting(int short_count) // Y 스테이지 포인트 설정 함수
        {
            //int i = 0;
            //double y_move_left = 0;
            short_point[0] = Convert.ToDouble(short_point_end.Value);
            short_point[1] = Convert.ToDouble(short_point_0.Value);

            switch (short_count)
            {
                case 1:
                    y_stage_point = short_point[0];
                    break;

                case 2:
                    y_stage_point = short_point[1];
                    break;
            }
            return y_stage_point;
        }

        public decimal z_point_setting(int z_setting_int)
        {
            //z_point
            z_point[0] = z_point_1.Value; //150
            z_point[1] = z_point_2.Value; //450
            z_point[2] = z_point_3.Value; //750
            //long_point[3] = Convert.ToDouble(Long_point4.Value);

            switch (z_setting_int)
            {
                case 1:
                    z_posision = z_point[0];
                    break;
                case 2:
                    z_posision = z_point[1];
                    break;
                case 3:
                    z_posision = z_point[2];
                    break;
            }
            return z_posision;
        }


        public async Task<string> short_move_cycle(int cycle_count, string sign)
        {

            string short_signal = "";
            bool ok_sign = false;




            var task3_1 = Task.Run(() =>
            {
                //short_point_setting(2);
                //var comm_y = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                //send_function(comm_y);
                //Thread.Sleep(100);

                for (int i = 0; i < cycle_count; i++) //4
                {
                    if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                    {
                        if (y_stage_point > 50)
                        {
                            short_point_setting(2); //0
                            var comm_y_1 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                            send_function(comm_y_1);
                            break;
                        }
                        else
                        {
                            short_point_setting(1); //249
                            var comm_y_1 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                            send_function(comm_y_1);
                            break;
                        }
                    }

                    while (y_complete != Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                    {
                        var comm_posi = posi_check_robot("0");
                        y_position_compare(comm_posi);

                        y_complete = Convert.ToDecimal(y_position);

                        if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                        {
                            if (y_stage_point > 50)
                            {
                                short_point_setting(2); //0
                                var comm_y_1 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                send_function(comm_y_1);
                                break;
                            }
                            else
                            {
                                short_point_setting(1); //249
                                var comm_y_1 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                send_function(comm_y_1);
                                break;
                            }
                        }
                    }
                }
            });
            //task3_1.Wait();
            await task3_1;
            /*
                var task3_2 = Task.Run(() =>
                {
                    if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                    {
                        serialPort1.Write(close_str);
                        posf = move_back(ma_pos_val); // 7번 z stg 대기 위치 (-5mm)
                        Move_Method1(device, posf);

                        //posf = Convert.ToDecimal(ma_pos_val);// 2번 z stg 앞 이동
                    }
                    while (y_complete != Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                    {
                        var comm_posi = posi_check_robot("0");
                        y_position_compare(comm_posi);

                        y_complete = Convert.ToDecimal(y_position);

                        if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                        {
                            serialPort1.Write(close_str);
                            posf = move_back(ma_pos_val); // 7번 z stg 대기 위치 (-5mm)
                            Move_Method1(device, posf);
                            break;
                        }
                    }
                });
                task3_2.Wait();
            */
            ok_sign = task3_1.IsCompleted;

            //

            if (ok_sign == true)
            {
                short_signal = "ok";
            }



            return short_signal;
        }

        private async void one_step_Click(object sender, EventArgs e)
        {

            shutter_dist = Convert.ToDouble(off_dist.Value);
            double t = Convert.ToDouble(on_delay.Value);
            shutter_delay_time = Convert.ToInt16(t * 1000);

            decimal y_axis_pt_a1 = str_pt_y.Value;
            string point_a2 = y_axis_pt_a1.ToString(ltn_stra2);

            decimal x_axis_pt_a1 = str_pt_x.Value;
            string point_a1 = x_axis_pt_a1.ToString(ltn_stra1);

            y_pitch_size = Convert.ToDouble(short_point_end.Value);//전역
            y_start_point = Convert.ToDouble(short_point_0.Value);//전역

            y_stage_point = 0;//전역                     
            y_complete = 0;

            int scan_count = Convert.ToInt16(scanning_count.Value);
            string sign = "";

            decimal velocity = z_stg_spd.Value;

            VelocityParameters velPars = device.GetVelocityParams();
            velPars.MaxVelocity = velocity;
            device.SetVelocityParams(velPars);

            double st = Convert.ToDouble(mast_start.Value);
            //ma_pos_val = 300 - st;
            one_step.Enabled = false;
         
            if (direction_check.Checked == false && scan_count > 1)
            {
                //short_move_cycle(scan_count, sign);

                decimal speed_short = short_spd.Value;
                string spd = speed_short.ToString(spd_str);
                var comm_spd = speed("0", spd);
                send_function(comm_spd);
                Thread.Sleep(100);

                short_point_setting(1); //249
                var comm_y_1 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                send_function(comm_y_1);
                Thread.Sleep(shutter_delay_time);
                serialPort1.Write(open_str);// 3번 셔터 오픈                       

                for (int i = 1; i < scan_count; i++) //4
                {
                    var task3 = Task.Run(() =>
                    {

                        Thread.Sleep(500);
                        //while (y_complete != Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                        while (true) // y축 좌표 비교 이동 완료
                        {
                            var comm_posi = posi_check_robot("0");
                            y_position_compare(comm_posi);

                            y_complete = Convert.ToDecimal(y_position);

                            //var task3_1 = Task.Run(() =>
                            //{
                            double y_stage_point_1 = y_stage_point - (shutter_dist - 1);
                            double y_stage_point_2 = y_stage_point - shutter_dist;

                            if (Convert.ToDecimal(y_stage_point_2) < y_complete &&
                                y_complete < Convert.ToDecimal(y_stage_point_1)) // y축 좌표 비교 이동 완료
                            {
                                serialPort1.Write(close_str);
                            }
                            //});


                            if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                            {
                                if (y_stage_point > 0)
                                {
                                    short_point_setting(2); //0
                                    var comm_y_2 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                    send_function(comm_y_2);
                                    Thread.Sleep(shutter_delay_time);
                                    serialPort1.Write(open_str);// 3번 셔터 오픈                       

                                    break;
                                }
                                else
                                {
                                    short_point_setting(1); //249
                                    var comm_y_3 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                    send_function(comm_y_3);
                                    Thread.Sleep(shutter_delay_time);
                                    serialPort1.Write(open_str);// 3번 셔터 오픈                       

                                    break;
                                }
                            }
                            //task3_1.Wait();
                            //await task3_1;

                        }
                    });
                    await task3;
                    //await task3_1;
                    //task3.Wait();
                }

                var task3_2 = Task.Run(() =>
                {
                    Thread.Sleep(500);
                  
                    while (true) // y축 좌표 비교 이동 완료

                    {
                        var comm_posi = posi_check_robot("0");
                        y_position_compare(comm_posi);

                        y_complete = Convert.ToDecimal(y_position);

                        double y_stage_point_1 = y_stage_point + (shutter_dist - 1);
                        double y_stage_point_2 = y_stage_point + shutter_dist;

                        if (Convert.ToDecimal(y_stage_point_1) < y_complete &&
                            y_complete < Convert.ToDecimal(y_stage_point_2)) // y축 좌표 비교 이동 완료
                        {
                            serialPort1.Write(close_str);
                        }

                        if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                        {
                            //serialPort1.Write(close_str);
                            posf = move_back(ma_pos_val); // 7번 z stg 대기 위치 (-5mm)
                            Move_Method1(device, posf);
                            break;
                        }
                    }
                });
                await task3_2;
            }

            if (direction_check.Checked == false && scan_count == 1)
            {
                var task4 = Task.Run(() =>
                {
                    decimal speed_short = short_spd.Value;
                    string spd = speed_short.ToString(spd_str);
                    var comm_spd = speed("0", spd);
                    send_function(comm_spd);
                    Thread.Sleep(100);

                    short_point_setting(1); //249
                    var comm_y = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                    send_function(comm_y);
                    Thread.Sleep(shutter_delay_time);
                    serialPort1.Write(open_str);// 3번 셔터 오픈  

                    var task4_1 = Task.Run(() =>
                    {
                  
                        Thread.Sleep(500);

                        //while (y_complete != Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                        while (true) // y축 좌표 비교 이동 완료
                        {
                            var comm_posi = posi_check_robot("0");
                            //send_position(comm_posi);
                            y_position_compare(comm_posi);

                            y_complete = Convert.ToDecimal(y_position);

                            double y_stage_point_1 = y_stage_point - (shutter_dist - 1);
                            double y_stage_point_2 = y_stage_point - shutter_dist;

                            if (Convert.ToDecimal(y_stage_point_2) < y_complete &&
                                y_complete < Convert.ToDecimal(y_stage_point_1)) // y축 좌표 비교 이동 완료
                            {
                                serialPort1.Write(close_str);
                            }

                            if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                            {
                                //serialPort1.Write(close_str);
                                posf = move_back(ma_pos_val); // 7번 z stg 대기 위치 (-5mm)
                                Move_Method1(device, posf);

                                //posf = Convert.ToDecimal(ma_pos_val);// 2번 z stg 앞 이동
                                break;
                            }
                        }
                        // }
                    });
                    task4_1.Wait();
                });
                await task4;
            }




            if (direction_check.Checked == true && scan_count > 1)
            {
                decimal speed_short = short_spd.Value;
                string spd = speed_short.ToString(spd_str);
                var comm_spd = speed("0", spd);
                send_function(comm_spd);
                Thread.Sleep(100);

                //short_point_setting(1); //249
                //var comm_y = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                //send_function(comm_y);
                //Thread.Sleep(100);

                for (int i = 1; i < scan_count * 2; i++) //2 4 6 8 
                {
                    var task2 = Task.Run(() =>
                    {
                        if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                        {
                            if (y_stage_point > 50)
                            {
                                serialPort1.Write(close_str);

                                short_point_setting(2); //0
                                var comm_y_1 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                send_function(comm_y_1);
                            }
                            else
                            {
                                serialPort1.Write(open_str);

                                short_point_setting(1); //249
                                var comm_y_1 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                send_function(comm_y_1);
                            }
                        }

                        while (y_complete != Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                        {
                            var comm_posi_1 = posi_check_robot("0");
                            y_position_compare(comm_posi_1);

                            y_complete = Convert.ToDecimal(y_position);

                            if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                            {
                                if (y_stage_point > 50)
                                {
                                    serialPort1.Write(close_str);

                                    short_point_setting(2); //249
                                    var comm_y_2 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                    send_function(comm_y_2);
                                    break;
                                }
                                else
                                {
                                    serialPort1.Write(open_str);

                                    short_point_setting(1); //0
                                    var comm_y_2 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                    send_function(comm_y_2);
                                    break;

                                }
                            }
                        }
                    });
                    await task2;
                }


                var task2_2 = Task.Run(() =>
                {
                    while (y_complete != Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                    {
                        var comm_posi_1 = posi_check_robot("0");
                        y_position_compare(comm_posi_1);

                        y_complete = Convert.ToDecimal(y_position);

                        if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                        {
                            if (y_stage_point > 50)
                            {
                                serialPort1.Write(close_str);

                                short_point_setting(2); //0
                                var comm_y_1 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                send_function(comm_y_1);
                                break;

                            }
                            else
                            {
                                serialPort1.Write(close_str);

                                break;
                            }

                        }
                    }
                });
                await task2_2;

                var task2_1 = Task.Run(() =>
                {

                    if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                    {
                        posf = move_back(ma_pos_val); //7번 z stg 대기 위치 (-5mm)
                        Move_Method1(device, posf);
                        //posf = Convert.ToDecimal(ma_pos_val);// 2번 z stg 앞 이동
                    }

                    while (y_complete != Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                    {
                        var comm_posi = posi_check_robot("0");
                        y_position_compare(comm_posi);

                        y_complete = Convert.ToDecimal(y_position);

                        if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                        {
                            posf = move_back(ma_pos_val); // 7번 z stg 대기 위치 (-5mm)
                            Move_Method1(device, posf);
                            break;
                        }
                    }
                });
                await task2_1;
            }









            var task_origin = Task.Run(() =>
            {
                decimal speed_long = long_spd.Value;
                string spd_long = speed_long.ToString(spd_str);
                var comm = speed("0", spd_long);
                send_function(comm);
                Thread.Sleep(100);

                //string pos_s = Convert.ToString(mast_wait_posi);
                //posf = Convert.ToDecimal(pos_s);

                mast_wait_posi = 30.000;
                decimal posf_wait = Convert.ToDecimal(mast_wait_posi);// 1번 z stg 대기 위치까지 이동 
                Move_Method1(device, posf_wait);

                //var comm_origin = move_zero("0");
                //send_function(comm_origin);

                //150 롱 무빙 후 대기
                // 0  숏 무빙 후 대기
                //280 Z stg 무빙 후 홈

                //device.Home(0);

                var comm_x = move_axis_x("0", 998.000);
                send_function(comm_x);

                //Long_stage.Initialize();                        
                //Short_stage.Initialize();

                Array.Clear(Long_stage, 0x0, Long_stage.Length);
                Array.Clear(Short_stage, 0x0, Short_stage.Length);

                y_complete = 0;
                x_complete = 0;

                z_pos = 0;
                posf = 0;

                one_step.Enabled = true;
                Setup_position.Enabled = true;

                //x_stage_point = 0;
                //y_stage_point = 0;
            });
            await task_origin;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // UI 쓰레드에서 실행. 
            // UI 컨트롤 직접 엑세스 가능
            //label1.Text = DateTime.Now.ToLongTimeString();

            double complete_time = sw.Elapsed.TotalSeconds;
            complete_time = Math.Round(complete_time * 100) / 100;

            //this.Invoke(new Action(delegate ()
            //{
                lb_time.Text = Convert.ToString(complete_time);
            //}));
        }

        private async void full_step_Click(object sender, EventArgs e) //총 구동 시작
        {
            shutter_dist = Convert.ToDouble(off_dist.Value);
            double t = Convert.ToDouble(on_delay.Value);
            shutter_delay_time = Convert.ToInt16(t * 1000);


            decimal y_axis_pt_a1 = str_pt_y.Value;
            string point_a2 = y_axis_pt_a1.ToString(ltn_stra2);

            decimal x_axis_pt_a1 = str_pt_x.Value;
            string point_a1 = x_axis_pt_a1.ToString(ltn_stra1);


            y_pitch_size = Convert.ToDouble(short_point_end.Value);//전역
            y_start_point = Convert.ToDouble(short_point_0.Value);//전역

            y_stage_point = 0;//전역

            y_complete = 0;
            y_complete_db = 0;
            x_complete_db = 0;

            int scan_count = Convert.ToInt16(scanning_count.Value);
            string sign = "";

            decimal velocity = z_stg_spd.Value;

            VelocityParameters velPars = device.GetVelocityParams();
            velPars.MaxVelocity = velocity;
            device.SetVelocityParams(velPars);

            double st = Convert.ToDouble(mast_start.Value);
            //ma_pos_val = 300 - st;

            // string pos_s = Convert.ToString(ma_pos_val);   

            full_step.Enabled = false;

            for (int m = 0; m < full_step_count; m++)
            {
                if (m == 0)
                {
                    //short_point_setting(1); //249
                    long_point_setting(1);

                }
                else if (m == 1)
                {
                    //short_point_setting(2); //0
                    long_point_setting(2);

                }
                else if (m == 2)
                {
                    //short_point_setting(1); //249
                    long_point_setting(3);

                }
                else if (m == 3)
                {
                    //short_point_setting(2); //0
                    long_point_setting(4);

                }
                              

                z_pos = device.Position;

                var task1 = Task.Run(() =>
                {

                    if (z_pos == posf)
                    {
                    }
                    //Thread.Sleep(100);
                });
                await task1;


                //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

                if (direction_check.Checked == false && scan_count == 1)
                {

                    //var task_timer = Task.Run(() =>
                    //{
                        if (m == 0)
                        {
                            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                            timer.Interval = 1; // 1초
                            timer.Tick += new EventHandler(timer_Tick);
                            timer.Start();
                            //timer.
                            sw.Start();                      
                        }
                  
                    var task4 = Task.Run(() =>
                    {
                        decimal speed_short = short_spd.Value;
                        string spd = speed_short.ToString(spd_str);
                        var comm_spd = speed("0", spd);
                        send_function(comm_spd);
                        Thread.Sleep(100);

                        if (m % 2 == 0)
                        {
                            short_point_setting(1); //249
                        }
                        else
                        {
                            short_point_setting(2); //0
                        }

                        //device1.SetOperatingState(SolenoidStatus.OperatingStates.Active);
                        _serialPort.WriteLine("ens");

                        var comm_y = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                        send_function(comm_y);
                        //Thread.Sleep(shutter_delay_time);
                        //serialPort1.Write(open_str);// 3번 셔터 오픈  

                        y_stage_point = CustomRound(RoundType.Truncate, y_stage_point, 2);

                        var task4_1 = Task.Run(() =>
                            {
                            
                                Thread.Sleep(500);

                                while (true)
                                {
                                    var comm_posi = posi_check_robot("0");
                                //send_position(comm_posi);
                                y_position_compare(comm_posi);

                                //y_complete = Convert.ToDecimal(y_position);

                                y_complete_db = Convert.ToDouble(y_position);
                                y_complete_db = CustomRound(RoundType.Truncate, y_complete_db, 2);
                              
                                if (y_complete_db == y_stage_point) // y축 좌표 비교 이동 완료
                                {
                                        //device1.SetOperatingState(SolenoidStatus.OperatingStates.Inactive);
                                        _serialPort.WriteLine("ens");

                                        if (m == full_step_count - 1)
                                        {
                                        //serialPort1.Write(close_str);
                                        sw.Stop();
                                    
                                        mast_wait_posi = 30.000;
                                        decimal posf_wait = Convert.ToDecimal(mast_wait_posi);// 1번 z stg 대기 위치까지 이동 
                                        Move_Method1(device, posf_wait);
                                        z_posision = Convert.ToDecimal(40.000);

                                        //break;
                                    }
                                    //serialPort1.Write(close_str);
                                    //posf = move_back(ma_pos_val); // 7번 z stg 대기 위치 (-5mm)
                                    z_posision = move_back_val(z_posision); // 7번 z stg 대기 위치 (-5mm)                                    
                                    Move_Method1(device, z_posision);

                                    break;
                                    }
                                }
                            //}
                        });
                        task4_1.Wait();
                    });
                    await task4;
                }





                //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ


                if (direction_check.Checked == false && scan_count > 1)
                {
                    //short_move_cycle(scan_count, sign);                                

                    //    }
                    //}
                    //short_point_setting(1); //249
                    //double a = ;
                    short_point_setting(1); //0

                    for (int i = 1; i < scan_count; i++) //4
                    {

                        var task2 = Task.Run(() =>
                        {
                            decimal speed_short = short_spd.Value;
                            string spd = speed_short.ToString(spd_str);
                            var comm_spd = speed("0", spd);
                            send_function(comm_spd);
                            Thread.Sleep(100);

                            //if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                            //{
                            //    if (y_stage_point > 50)
                            //    {
                            //        short_point_setting(2); //0
                            //        var comm_y_1 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                            //        send_function(comm_y_1);
                            //    }
                            //    else
                            //    {
                            //700 180
                            if (y_stage_point > Convert.ToDouble(short_point_0.Value))
                            {
                                short_point_setting(1); //0
                                var comm_y_2 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                send_function(comm_y_2);

                                Thread.Sleep(shutter_delay_time);
                                serialPort1.Write(open_str);// 3번 셔터 오픈                       

                            }
                            else
                            {
                                short_point_setting(2); //249
                                var comm_y_2 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                send_function(comm_y_2);

                                Thread.Sleep(shutter_delay_time);
                                serialPort1.Write(open_str);// 3번 셔터 오픈                       

                            }

                            // serialPort1.Write(open_str);// 3번 셔터 오픈
                        });
                        await task2;


                        var task3 = Task.Run(() =>
                        {

                            //short_point_setting(1); //249
                            //var comm_y = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                            //send_function(comm_y);
                            //Thread.Sleep(100);
                            //var task3_1 = Task.Run(() =>
                            //{
                            Thread.Sleep(300);

                            //while (y_complete != Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                            while (true) // y축 좌표 비교 이동 완료
                            {
                                var comm_posi = posi_check_robot("0");
                                y_position_compare(comm_posi);

                                y_complete = Convert.ToDecimal(y_position);

                                /*
                                double y_stage_point_1 = y_stage_point - (shutter_dist - 1);
                                double y_stage_point_2 = y_stage_point - shutter_dist;

                                y_stage_point_1 = Math.Abs(y_stage_point_1); // 4 or 245
                                y_stage_point_2 = Math.Abs(y_stage_point_2); // 5 or 244

                                double x = y_stage_point_1;
                                double y = y_stage_point_2;

                                if (y_stage_point_1 > y_stage_point_2)
                                {
                                    y_stage_point_1 = y;
                                    y_stage_point_2 = x;
                                }

                                if (Convert.ToDecimal(y_stage_point_1) < y_complete && 
                                    y_complete < Convert.ToDecimal(y_stage_point_2)) // y축 좌표 비교 이동 완료
                                {
                                    serialPort1.Write(close_str);
                                }
                                */

                                if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                                {
                                    if (y_stage_point > Convert.ToDouble(short_point_0.Value))
                                    {
                                        short_point_setting(2); //0
                                        var comm_y_2 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                        send_function(comm_y_2);
                                        //Thread.Sleep(shutter_delay_time);
                                        //serialPort1.Write(open_str);// 3번 셔터 오픈                       
                                        //i++;

                                        break;
                                    }
                                    else
                                    {
                                        short_point_setting(1); //249
                                        var comm_y_2 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                        send_function(comm_y_2);
                                        //Thread.Sleep(shutter_delay_time);
                                        //serialPort1.Write(open_str);// 3번 셔터 오픈                       

                                        break;

                                    }

                                }
                            }

                            i++;


                            //  });
                            // task3_1.Wait();
                        });
                        await task3;

                        // if(i ==  scan_count - 1)
                        //  {
                        //      break;

                        // }

                    }

                    //short_point_setting(2); //0
                    //var comm_y_end = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                    //send_function(comm_y_end);

                    //Thread.Sleep(100);

                    var task3_2 = Task.Run(() =>
                    {
                        Thread.Sleep(500);

                        //if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                        //{
                        //    serialPort1.Write(close_str);
                        //    posf = move_back(ma_pos_val); // 7번 z stg 대기 위치 (-5mm)
                        //    Move_Method1(device, posf);

                        //posf = Convert.ToDecimal(ma_pos_val);// 2번 z stg 앞 이동
                        //}

                        //while (y_complete != Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                        while (true)
                        {
                            var comm_posi = posi_check_robot("0");
                            y_position_compare(comm_posi);

                            y_complete = Convert.ToDecimal(y_position);

                            /*
                            double y_stage_point_1 = y_stage_point + (shutter_dist - 1);
                            double y_stage_point_2 = y_stage_point + shutter_dist;

                            y_stage_point_1 = Math.Abs(y_stage_point_1); // 4 or 245
                            y_stage_point_2 = Math.Abs(y_stage_point_2); // 5 or 244

                            double x = y_stage_point_1;
                            double y = y_stage_point_2;

                            if (y_stage_point_1 > y_stage_point_2)
                            {
                                y_stage_point_1 = y;
                                y_stage_point_2 = x;
                            }

                            if (Convert.ToDecimal(y_stage_point_1) < y_complete && 
                                y_complete < Convert.ToDecimal(y_stage_point_2)) // y축 좌표 비교 이동 완료
                            {
                                serialPort1.Write(close_str);
                            }23
                            */

                            if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                            {
                                serialPort1.Write(close_str);
                                posf = move_back(ma_pos_val); // 7번 z stg 대기 위치 (-5mm)
                                Move_Method1(device, posf);
                                break;
                            }
                        }



                    });
                    //task3_2.Wait();
                    await task3_2;
                }









                if (direction_check.Checked == true && scan_count > 1)
                {
                    decimal speed_short = short_spd.Value;
                    string spd = speed_short.ToString(spd_str);
                    var comm_spd = speed("0", spd);
                    send_function(comm_spd);
                    Thread.Sleep(100);

                    //short_point_setting(1); //249
                    //var comm_y = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                    //send_function(comm_y);
                    //Thread.Sleep(100);



                    //if (scan_count % 2 == 0)
                    //{
                    for (int i = 1; i < scan_count * 2; i++) //2 4 6 8 
                    {
                        var task2 = Task.Run(() =>
                        {
                            if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                            {
                                if (y_stage_point > 50)
                                {
                                    serialPort1.Write(close_str);

                                    short_point_setting(2); //0
                                    var comm_y_1 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                    send_function(comm_y_1);
                                }
                                else
                                {
                                    serialPort1.Write(open_str);

                                    short_point_setting(1); //249
                                    var comm_y_1 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                    send_function(comm_y_1);
                                }
                            }

                            while (y_complete != Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                            {
                                var comm_posi_1 = posi_check_robot("0");
                                y_position_compare(comm_posi_1);

                                y_complete = Convert.ToDecimal(y_position);

                                if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                                {
                                    if (y_stage_point > 50)
                                    {
                                        serialPort1.Write(close_str);

                                        short_point_setting(2); //249
                                        var comm_y_2 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                        send_function(comm_y_2);
                                        break;
                                    }
                                    else
                                    {
                                        serialPort1.Write(open_str);

                                        short_point_setting(1); //0
                                        var comm_y_2 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                        send_function(comm_y_2);
                                        break;

                                    }
                                    //posf = move_front(ma_pos_val); // 7번 z stg 대기 위치 (-5mm)
                                    //Move_Method1(device, posf);                              
                                }
                            }
                        });
                        await task2;
                    }
                    //}

                    /*
                    else
                    {
                        for (int i = 0; i < scan_count + 2; i++) // 3번 
                        {
                            var task2_2 = Task.Run(() =>
                            {
                             
                                while (y_complete != Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                                {
                                    var comm_posi_1 = posi_check_robot("0");
                                    y_position_compare(comm_posi_1);

                                    y_complete = Convert.ToDecimal(y_position);

                                    if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                                    {
                                        if (y_stage_point > 50)
                                        {
                                            serialPort1.Write(open_str);
                                            short_point_setting(1); //249
                                            var comm_y_1 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                            send_function(comm_y_1);
                                            break;
                                        }
                                        else
                                        {
                                            serialPort1.Write(close_str);
                                            short_point_setting(2); //0
                                            var comm_y_1 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                            send_function(comm_y_1);
                                            break;

                                        }
                                        //posf = move_front(ma_pos_val); // 7번 z stg 대기 위치 (-5mm)
                                        //Move_Method1(device, posf);                              
                                    }
                                }
                            });
                            await task2_2;
                        }
                    }
                    */


                    var task2_2 = Task.Run(() =>
                        {
                            while (y_complete != Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                            {
                                var comm_posi_1 = posi_check_robot("0");
                                y_position_compare(comm_posi_1);

                                y_complete = Convert.ToDecimal(y_position);

                                if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                                {
                                    if (y_stage_point > 50)
                                    {
                                        serialPort1.Write(close_str);

                                        short_point_setting(2); //0
                                        var comm_y_1 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                                        send_function(comm_y_1);
                                        break;

                                    }
                                    else
                                    {
                                        serialPort1.Write(close_str);

                                        break;
                                    }

                                }
                            }
                        });
                    await task2_2;

                    var task2_1 = Task.Run(() =>
                    {
                        /*
                        if (y_stage_point > 50)
                        {
                            serialPort1.Write(close_str);

                            short_point_setting(2); //0
                            var comm_y_end = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                            send_function(comm_y_end);
                        }
                        else
                        {
                            serialPort1.Write(close_str);

                            //short_point_setting(2); //0
                            //var comm_y_end = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)  
                            //send_function(comm_y_end);
                        }
                        */
                        if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                        {
                            posf = move_back(ma_pos_val); //7번 z stg 대기 위치 (-5mm)
                            Move_Method1(device, posf);
                            //posf = Convert.ToDecimal(ma_pos_val);// 2번 z stg 앞 이동
                        }

                        while (y_complete != Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                        {
                            var comm_posi = posi_check_robot("0");
                            y_position_compare(comm_posi);

                            y_complete = Convert.ToDecimal(y_position);

                            if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                            {
                                posf = move_back(ma_pos_val); // 7번 z stg 대기 위치 (-5mm)
                                Move_Method1(device, posf);
                                break;
                            }
                        }
                    });
                    await task2_1;
                }

                //Thread.Sleep(3000);// 5번 y축 이동 후 현재 좌표와 설정한 좌표 비교 
                //var comm_posi = posi_check_robot("0");

                //Parallel.Invoke(() => 
                //{ 
                //y_position_compare(comm_posi); 
                //}      
                //);

                /*
                if (m == full_step_count - 1)
                {
                    serialPort1.Write(close_str);
                    sw.Stop();
                    //int complete_time = sw.Elapsed.Seconds;

                    double complete_time = sw.Elapsed.TotalSeconds;
                    complete_time = Math.Round(complete_time * 100) / 100;

                    this.Invoke(new Action(delegate ()
                    {
                        lb_time.Text = Convert.ToString(complete_time) + "초";
                    }));
                    sw.Reset();
                }

                */
                if (m == 0)
                {
                    long_point_setting(2);
                    z_point_setting(2);
                }
                else if (m == 1)
                {
                    long_point_setting(3);
                    z_point_setting(3);

                }
                else if (m == 2)
                {
                    //long_point_setting(3);
                }
                else if (m == 3)
                {
                    //short_point_setting(2);
                    //long_point_setting(4);
                }

                var task0 = Task.Run(() =>
                {
                    decimal speed_long = long_spd.Value;
                    string spd_long = speed_long.ToString(spd_str);
                    var comm = speed("0", spd_long);
                    send_function(comm);
                    Thread.Sleep(100);

                    var comm_x = move_axis_x("0", x_stage_point);
                    send_function(comm_x);
                    Thread.Sleep(100);

                    //decimal a = Convert.ToDecimal(x_stage_point);
                    //double b = Convert.ToDouble(x_stage_point);

                    Thread.Sleep(500);

                    x_stage_point = CustomRound(RoundType.Truncate, x_stage_point, 2);

                    //while (x_complete != Convert.ToDecimal(x_stage_point)) // y축 좌표 비교 이동 완료
                    while (true)
                    {
                        //Thread.Sleep(100);
                        var comm_posi = posi_check_robot("0");
                        x_position_compare(comm_posi);
                        x_complete_db = Convert.ToDouble(x_position);
                        x_complete_db = CustomRound(RoundType.Truncate, x_complete_db, 2);

                        if (x_complete_db == x_stage_point) // y축 좌표 비교 이동 완료
                        {                            
                            Move_Method1(device, z_posision);

                            z_pos = device.Position;

                            if (z_pos == z_posision)
                            {
                                break;
                            }
                        }
                    }
                });
                await task0;

                if (m == full_step_count - 1)
                {
                    var task_origin = Task.Run(() =>
                    {
                        mast_wait_posi = 30.000;                    

                        decimal posf_wait = Convert.ToDecimal(mast_wait_posi);// 1번 z stg 대기 위치까지 이동 
                        Move_Method1(device, posf_wait);                    

                        //150 롱 무빙 후 대기
                        // 0  숏 무빙 후 대기
                        //280 Z stg 무빙 후 홈

                        //device.Home(0);

                        var comm_x = move_axis_x("0", 998.000);
                        send_function(comm_x);

                        Array.Clear(Long_stage, 0x0, Long_stage.Length);
                        Array.Clear(Short_stage, 0x0, Short_stage.Length);

                        y_complete = 0;
                        x_complete = 0;

                        z_pos = 0;
                        posf = 0;

                        full_step.Enabled = true;
                        Setup_position.Enabled = true;        
                    });
                    await task_origin;
                }
            }
        }





        private void thorlabs_sh_connect_Click(object sender, EventArgs e)
        {


            var task_shutter = Task.Run(() =>
            {
                _serialPort.PortName = comboBox1.SelectedItem.ToString(); //"COM12";
                _serialPort.BaudRate = 9600;
                _serialPort.Parity = Parity.None;
                _serialPort.DataBits = 8;
                _serialPort.StopBits = StopBits.One;
                    // Set the read/write timeouts
                  _serialPort.ReadTimeout = -1; //1000
                _serialPort.WriteTimeout = -1;    //1000
                _serialPort.NewLine = "\r";


                _serialPort.Open();

                if (_serialPort.IsOpen == true)
                {
                    Thread.Sleep(500);
                    _serialPort.WriteLine("\n");

                    textBox2.Text = "Shutter Connected";
                    thorlabs_sh_connect.Enabled = false;
                    Thread.Sleep(500);
                }
            });


        }
        private void button5_Click(object sender, EventArgs e)
        {
            _serialPort.WriteLine("ens");

        }




        private enum RoundType
        {
            Ceiling,
            Round,
            Truncate
        }

        

        static private double CustomRound(RoundType roundType, double value, int digit = 1)
        {
            double dReturn = 0;
            double digitCal = Math.Pow(10, digit) / 10;

            switch (roundType)
            {
                case RoundType.Ceiling:
                    dReturn = Math.Ceiling(value * digitCal) / digitCal;
                    break;
                case RoundType.Round:
                    dReturn = Math.Round(value * digitCal) / digitCal;
                    break;
                case RoundType.Truncate:
                    dReturn = Math.Truncate(value * digitCal) / digitCal;
                    break;
            }
            return dReturn;
        }


        private async void setup_position_Click(object sender, EventArgs e)
        {

            sw.Reset();

            decimal velocity = z_stg_spd.Value;

            VelocityParameters velPars = device.GetVelocityParams();
            velPars.MaxVelocity = velocity;
            device.SetVelocityParams(velPars);

            double st = Convert.ToDouble(mast_start.Value);
            ma_pos_val = 300 - st;

            short_point_setting(2); //0
            long_point_setting(1);
            z_point_setting(1);

            //device.
            //Action<UInt64> workDone = 
            //Short_stage = y_stage_point;
            //if(lb_time.Text.)

            //this.Invoke(new Action(delegate ()
            //{
            //    lb_time.ResetText();
            //}));

            /*
            var task0 = Task.Run(() =>
            {
                var comm_y_1 = move_axis_y("0", y_stage_point);// 4번 y축 이동 (0 ~ 249)
                send_function(comm_y_1);
            });
            await task0;
            */



            var task0_1 = Task.Run(() =>
            {
                //decimal speed_long = long_spd.Value;
                decimal speed_long = 300;
                string spd_long = speed_long.ToString(spd_str);
                var comm = speed("0", spd_long);
                send_function(comm);
                Thread.Sleep(300);

                var comm_x = move_axis_all("0", x_stage_point, y_stage_point);
                send_function(comm_x);
                Thread.Sleep(300);

                decimal a = Convert.ToDecimal(x_stage_point);
                //double b = Convert.ToDouble(x_stage_point);

                while (x_complete != Convert.ToDecimal(x_stage_point)) // y축 좌표 비교 이동 완료
                {
                    Thread.Sleep(300);
                    var comm_posi = posi_check_robot("0");
                    send_position(comm_posi);

                    x_complete = Convert.ToDecimal(x_position);

                    if (x_complete == Convert.ToDecimal(x_stage_point)) // y축 좌표 비교 이동 완료
                    {
                        //posf = move_front(ma_pos_val);// 2번 z stg 앞 이동
                        //posf = Convert.ToDecimal(ma_pos_val);// 1번 z stg 대기 위치까지 이동 

                        Move_Method1(device, z_posision);
                        Thread.Sleep(300);

                        z_pos = device.Position;

                        if (z_pos == z_posision)
                        {
                            //x_stage_point = 0;
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                Setup_position.Enabled = false;
                            }));
                            //y_stage_point = 0;
                            break;
                        }
                    }
                }
            });
            await task0_1;
        }
    }


}

