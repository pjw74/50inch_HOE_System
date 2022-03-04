
namespace one_socket_thread
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.spd_set = new System.Windows.Forms.Button();
            this.short_spd = new System.Windows.Forms.NumericUpDown();
            this.MOTOR_SPEED = new System.Windows.Forms.Label();
            this.stg_dis = new System.Windows.Forms.Button();
            this.stg_con = new System.Windows.Forms.Button();
            this.error_reset = new System.Windows.Forms.Button();
            this.rebot_controller = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.origin = new System.Windows.Forms.Button();
            this.sv_on = new System.Windows.Forms.Button();
            this.sv_off = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_x_position = new System.Windows.Forms.Label();
            this.lb_y_position = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.posi_chk = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.long_left = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.long_right = new System.Windows.Forms.Button();
            this.short_left = new System.Windows.Forms.Button();
            this.short_right = new System.Windows.Forms.Button();
            this.start_point = new System.Windows.Forms.Button();
            this.stage_move = new System.Windows.Forms.Button();
            this.pitch_val_y = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.str_pt_y = new System.Windows.Forms.NumericUpDown();
            this.str_pt_x = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pitch_val_x = new System.Windows.Forms.NumericUpDown();
            this.y_array = new System.Windows.Forms.NumericUpDown();
            this.x_array = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label15 = new System.Windows.Forms.Label();
            this.Baud_Combox = new System.Windows.Forms.ComboBox();
            this.Port_Combox = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.exposure_time = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Open_btn = new System.Windows.Forms.Button();
            this.Close_btn = new System.Windows.Forms.Button();
            this.button_shutter_open = new System.Windows.Forms.Button();
            this.button_shutter_close = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.mast_st_pnt = new System.Windows.Forms.Button();
            this.mast_pitch = new System.Windows.Forms.NumericUpDown();
            this.mast_start = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lts_disscon = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.buttonStop = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.one_step = new System.Windows.Forms.Button();
            this.full_step = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.z_pitch = new System.Windows.Forms.NumericUpDown();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.z_point_3 = new System.Windows.Forms.NumericUpDown();
            this.z_point_2 = new System.Windows.Forms.NumericUpDown();
            this.z_point_1 = new System.Windows.Forms.NumericUpDown();
            this.label37 = new System.Windows.Forms.Label();
            this.on_delay = new System.Windows.Forms.NumericUpDown();
            this.label35 = new System.Windows.Forms.Label();
            this.off_dist = new System.Windows.Forms.NumericUpDown();
            this.direction_check = new System.Windows.Forms.CheckBox();
            this.label36 = new System.Windows.Forms.Label();
            this.scanning_count = new System.Windows.Forms.NumericUpDown();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.lb_time = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.short_point_end = new System.Windows.Forms.NumericUpDown();
            this.short_point_0 = new System.Windows.Forms.NumericUpDown();
            this.Setup_position = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.Long_point5 = new System.Windows.Forms.NumericUpDown();
            this.Long_point4 = new System.Windows.Forms.NumericUpDown();
            this.Long_point3 = new System.Windows.Forms.NumericUpDown();
            this.Long_point2 = new System.Windows.Forms.NumericUpDown();
            this.Long_point1 = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            this.z_start_point = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.z_stg_spd = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.counting_num = new System.Windows.Forms.NumericUpDown();
            this.move_stop = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.long_spd = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.thorlabs_sh_connect = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label43 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.short_spd)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pitch_val_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.str_pt_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.str_pt_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitch_val_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_array)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_array)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exposure_time)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mast_pitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mast_start)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.z_pitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_point_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_point_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_point_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.on_delay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.off_dist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scanning_count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.short_point_end)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.short_point_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Long_point5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Long_point4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Long_point3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Long_point2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Long_point1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_stg_spd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.counting_num)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.long_spd)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // spd_set
            // 
            this.spd_set.Location = new System.Drawing.Point(283, 50);
            this.spd_set.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.spd_set.Name = "spd_set";
            this.spd_set.Size = new System.Drawing.Size(76, 32);
            this.spd_set.TabIndex = 86;
            this.spd_set.Text = "Speed Set";
            this.spd_set.UseVisualStyleBackColor = true;
            this.spd_set.Click += new System.EventHandler(this.spd_set_Click);
            // 
            // short_spd
            // 
            this.short_spd.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.short_spd.Location = new System.Drawing.Point(129, 33);
            this.short_spd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.short_spd.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.short_spd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.short_spd.Name = "short_spd";
            this.short_spd.Size = new System.Drawing.Size(59, 21);
            this.short_spd.TabIndex = 204;
            this.short_spd.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // MOTOR_SPEED
            // 
            this.MOTOR_SPEED.AutoSize = true;
            this.MOTOR_SPEED.Location = new System.Drawing.Point(10, 36);
            this.MOTOR_SPEED.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MOTOR_SPEED.Name = "MOTOR_SPEED";
            this.MOTOR_SPEED.Size = new System.Drawing.Size(110, 12);
            this.MOTOR_SPEED.TabIndex = 84;
            this.MOTOR_SPEED.Text = "Short Stage Speed";
            // 
            // stg_dis
            // 
            this.stg_dis.Location = new System.Drawing.Point(194, 11);
            this.stg_dis.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.stg_dis.Name = "stg_dis";
            this.stg_dis.Size = new System.Drawing.Size(122, 21);
            this.stg_dis.TabIndex = 83;
            this.stg_dis.Text = "Stage Disconnect";
            this.stg_dis.UseVisualStyleBackColor = true;
            this.stg_dis.Click += new System.EventHandler(this.stg_dis_Click);
            // 
            // stg_con
            // 
            this.stg_con.Location = new System.Drawing.Point(15, 11);
            this.stg_con.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.stg_con.Name = "stg_con";
            this.stg_con.Size = new System.Drawing.Size(159, 21);
            this.stg_con.TabIndex = 82;
            this.stg_con.Text = "Stage Connect";
            this.stg_con.UseVisualStyleBackColor = true;
            this.stg_con.Click += new System.EventHandler(this.stg_con_Click);
            // 
            // error_reset
            // 
            this.error_reset.Location = new System.Drawing.Point(19, 61);
            this.error_reset.Name = "error_reset";
            this.error_reset.Size = new System.Drawing.Size(111, 23);
            this.error_reset.TabIndex = 103;
            this.error_reset.Text = "Error Reset";
            this.error_reset.UseVisualStyleBackColor = true;
            this.error_reset.Click += new System.EventHandler(this.error_reset_Click);
            // 
            // rebot_controller
            // 
            this.rebot_controller.Location = new System.Drawing.Point(19, 26);
            this.rebot_controller.Name = "rebot_controller";
            this.rebot_controller.Size = new System.Drawing.Size(111, 25);
            this.rebot_controller.TabIndex = 107;
            this.rebot_controller.Text = "Rebot Controller";
            this.rebot_controller.UseVisualStyleBackColor = true;
            this.rebot_controller.Click += new System.EventHandler(this.rebot_controller_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rebot_controller);
            this.groupBox2.Controls.Add(this.origin);
            this.groupBox2.Controls.Add(this.sv_on);
            this.groupBox2.Controls.Add(this.sv_off);
            this.groupBox2.Controls.Add(this.error_reset);
            this.groupBox2.Location = new System.Drawing.Point(644, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 139);
            this.groupBox2.TabIndex = 106;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controller";
            // 
            // origin
            // 
            this.origin.Location = new System.Drawing.Point(19, 95);
            this.origin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.origin.Name = "origin";
            this.origin.Size = new System.Drawing.Size(111, 23);
            this.origin.TabIndex = 101;
            this.origin.Text = "Origin Move";
            this.origin.UseVisualStyleBackColor = true;
            this.origin.Click += new System.EventHandler(this.origin_Click);
            // 
            // sv_on
            // 
            this.sv_on.Location = new System.Drawing.Point(137, 26);
            this.sv_on.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sv_on.Name = "sv_on";
            this.sv_on.Size = new System.Drawing.Size(88, 25);
            this.sv_on.TabIndex = 104;
            this.sv_on.Text = "SERVO On";
            this.sv_on.UseVisualStyleBackColor = true;
            this.sv_on.Click += new System.EventHandler(this.sv_on_Click);
            // 
            // sv_off
            // 
            this.sv_off.Location = new System.Drawing.Point(137, 61);
            this.sv_off.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sv_off.Name = "sv_off";
            this.sv_off.Size = new System.Drawing.Size(88, 23);
            this.sv_off.TabIndex = 105;
            this.sv_off.Text = "SERVO Off";
            this.sv_off.UseVisualStyleBackColor = true;
            this.sv_off.Click += new System.EventHandler(this.sv_off_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 57;
            this.label3.Text = "Long";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 12);
            this.label1.TabIndex = 56;
            this.label1.Text = "Short";
            // 
            // lb_x_position
            // 
            this.lb_x_position.AutoSize = true;
            this.lb_x_position.Location = new System.Drawing.Point(52, 92);
            this.lb_x_position.Name = "lb_x_position";
            this.lb_x_position.Size = new System.Drawing.Size(57, 12);
            this.lb_x_position.TabIndex = 56;
            this.lb_x_position.Text = "  000.000 ";
            this.lb_x_position.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_y_position
            // 
            this.lb_y_position.AutoSize = true;
            this.lb_y_position.Location = new System.Drawing.Point(52, 113);
            this.lb_y_position.Name = "lb_y_position";
            this.lb_y_position.Size = new System.Drawing.Size(57, 12);
            this.lb_y_position.TabIndex = 58;
            this.lb_y_position.Text = "  000.000 ";
            this.lb_y_position.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 12);
            this.label2.TabIndex = 59;
            this.label2.Text = "mm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 12);
            this.label4.TabIndex = 60;
            this.label4.Text = "mm";
            // 
            // posi_chk
            // 
            this.posi_chk.Location = new System.Drawing.Point(145, 97);
            this.posi_chk.Name = "posi_chk";
            this.posi_chk.Size = new System.Drawing.Size(88, 25);
            this.posi_chk.TabIndex = 102;
            this.posi_chk.Text = "Position";
            this.posi_chk.Click += new System.EventHandler(this.posi_chk_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 40);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(159, 27);
            this.textBox1.TabIndex = 100;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.long_left);
            this.groupBox1.Controls.Add(this.lb_x_position);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lb_y_position);
            this.groupBox1.Controls.Add(this.long_right);
            this.groupBox1.Controls.Add(this.short_left);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.short_right);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.posi_chk);
            this.groupBox1.Location = new System.Drawing.Point(14, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 139);
            this.groupBox1.TabIndex = 108;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Jog Move";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 58);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 12);
            this.label8.TabIndex = 64;
            this.label8.Text = "Short";
            // 
            // long_left
            // 
            this.long_left.Location = new System.Drawing.Point(52, 28);
            this.long_left.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.long_left.Name = "long_left";
            this.long_left.Size = new System.Drawing.Size(88, 21);
            this.long_left.TabIndex = 69;
            this.long_left.Text = "Left";
            this.long_left.UseVisualStyleBackColor = true;
            this.long_left.Click += new System.EventHandler(this.x_right_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 32);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 12);
            this.label7.TabIndex = 65;
            this.label7.Text = "Long";
            // 
            // long_right
            // 
            this.long_right.Location = new System.Drawing.Point(145, 28);
            this.long_right.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.long_right.Name = "long_right";
            this.long_right.Size = new System.Drawing.Size(88, 21);
            this.long_right.TabIndex = 68;
            this.long_right.Text = "Right";
            this.long_right.UseVisualStyleBackColor = true;
            this.long_right.Click += new System.EventHandler(this.x_left_Click);
            // 
            // short_left
            // 
            this.short_left.Location = new System.Drawing.Point(52, 54);
            this.short_left.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.short_left.Name = "short_left";
            this.short_left.Size = new System.Drawing.Size(88, 21);
            this.short_left.TabIndex = 66;
            this.short_left.Text = "Left";
            this.short_left.UseVisualStyleBackColor = true;
            this.short_left.Click += new System.EventHandler(this.y_up_Click);
            // 
            // short_right
            // 
            this.short_right.Location = new System.Drawing.Point(145, 54);
            this.short_right.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.short_right.Name = "short_right";
            this.short_right.Size = new System.Drawing.Size(88, 21);
            this.short_right.TabIndex = 67;
            this.short_right.Text = "Right";
            this.short_right.UseVisualStyleBackColor = true;
            this.short_right.Click += new System.EventHandler(this.y_down_Click);
            // 
            // start_point
            // 
            this.start_point.Location = new System.Drawing.Point(819, 11);
            this.start_point.Name = "start_point";
            this.start_point.Size = new System.Drawing.Size(99, 23);
            this.start_point.TabIndex = 122;
            this.start_point.Text = "Go Start Point";
            this.start_point.UseVisualStyleBackColor = true;
            this.start_point.Visible = false;
            this.start_point.Click += new System.EventHandler(this.start_point_Click);
            // 
            // stage_move
            // 
            this.stage_move.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.stage_move.Location = new System.Drawing.Point(875, 198);
            this.stage_move.Name = "stage_move";
            this.stage_move.Size = new System.Drawing.Size(152, 41);
            this.stage_move.TabIndex = 121;
            this.stage_move.Text = "Stage Move";
            this.stage_move.UseVisualStyleBackColor = true;
            this.stage_move.Visible = false;
            this.stage_move.Click += new System.EventHandler(this.stage_move_Click);
            // 
            // pitch_val_y
            // 
            this.pitch_val_y.DecimalPlaces = 3;
            this.pitch_val_y.Location = new System.Drawing.Point(149, 98);
            this.pitch_val_y.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pitch_val_y.Maximum = new decimal(new int[] {
            995,
            0,
            0,
            0});
            this.pitch_val_y.Name = "pitch_val_y";
            this.pitch_val_y.Size = new System.Drawing.Size(85, 21);
            this.pitch_val_y.TabIndex = 120;
            this.pitch_val_y.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 98);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 12);
            this.label9.TabIndex = 119;
            this.label9.Text = "Pitch (Short)";
            this.label9.Visible = false;
            // 
            // str_pt_y
            // 
            this.str_pt_y.DecimalPlaces = 3;
            this.str_pt_y.Location = new System.Drawing.Point(149, 74);
            this.str_pt_y.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.str_pt_y.Maximum = new decimal(new int[] {
            995,
            0,
            0,
            0});
            this.str_pt_y.Name = "str_pt_y";
            this.str_pt_y.Size = new System.Drawing.Size(85, 21);
            this.str_pt_y.TabIndex = 118;
            // 
            // str_pt_x
            // 
            this.str_pt_x.DecimalPlaces = 3;
            this.str_pt_x.Location = new System.Drawing.Point(149, 24);
            this.str_pt_x.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.str_pt_x.Maximum = new decimal(new int[] {
            995,
            0,
            0,
            0});
            this.str_pt_x.Name = "str_pt_x";
            this.str_pt_x.Size = new System.Drawing.Size(85, 21);
            this.str_pt_x.TabIndex = 117;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 76);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 12);
            this.label10.TabIndex = 116;
            this.label10.Text = "Start Point (Short)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 26);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 12);
            this.label11.TabIndex = 115;
            this.label11.Text = "Start Point (Long)";
            // 
            // pitch_val_x
            // 
            this.pitch_val_x.DecimalPlaces = 3;
            this.pitch_val_x.Location = new System.Drawing.Point(149, 49);
            this.pitch_val_x.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pitch_val_x.Maximum = new decimal(new int[] {
            995,
            0,
            0,
            0});
            this.pitch_val_x.Name = "pitch_val_x";
            this.pitch_val_x.Size = new System.Drawing.Size(85, 21);
            this.pitch_val_x.TabIndex = 114;
            this.pitch_val_x.Visible = false;
            // 
            // y_array
            // 
            this.y_array.Location = new System.Drawing.Point(932, 222);
            this.y_array.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.y_array.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.y_array.Name = "y_array";
            this.y_array.Size = new System.Drawing.Size(38, 21);
            this.y_array.TabIndex = 113;
            this.y_array.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.y_array.Visible = false;
            // 
            // x_array
            // 
            this.x_array.Location = new System.Drawing.Point(863, 222);
            this.x_array.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.x_array.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.x_array.Name = "x_array";
            this.x_array.Size = new System.Drawing.Size(39, 21);
            this.x_array.TabIndex = 112;
            this.x_array.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.x_array.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(911, 227);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 12);
            this.label12.TabIndex = 111;
            this.label12.Text = "X";
            this.label12.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(844, 224);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 12);
            this.label13.TabIndex = 110;
            this.label13.Text = "ARRAY SIZE (X x Y)";
            this.label13.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 52);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 12);
            this.label14.TabIndex = 109;
            this.label14.Text = "Pitch (Long)";
            this.label14.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // timer2
            // 
            this.timer2.Interval = 250;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(198, 98);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 12);
            this.label15.TabIndex = 131;
            this.label15.Text = "(sec)";
            // 
            // Baud_Combox
            // 
            this.Baud_Combox.DisplayMember = "9600";
            this.Baud_Combox.FormattingEnabled = true;
            this.Baud_Combox.Items.AddRange(new object[] {
            "9600"});
            this.Baud_Combox.Location = new System.Drawing.Point(121, 60);
            this.Baud_Combox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Baud_Combox.Name = "Baud_Combox";
            this.Baud_Combox.Size = new System.Drawing.Size(66, 20);
            this.Baud_Combox.TabIndex = 128;
            this.Baud_Combox.Text = "9600";
            // 
            // Port_Combox
            // 
            this.Port_Combox.FormattingEnabled = true;
            this.Port_Combox.Location = new System.Drawing.Point(121, 30);
            this.Port_Combox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Port_Combox.Name = "Port_Combox";
            this.Port_Combox.Size = new System.Drawing.Size(66, 20);
            this.Port_Combox.TabIndex = 127;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 63);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 12);
            this.label18.TabIndex = 126;
            this.label18.Text = "Shutter Baud Rate";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 33);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(103, 12);
            this.label19.TabIndex = 125;
            this.label19.Text = "Shutter COM Port";
            // 
            // exposure_time
            // 
            this.exposure_time.DecimalPlaces = 1;
            this.exposure_time.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.exposure_time.Location = new System.Drawing.Point(121, 90);
            this.exposure_time.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.exposure_time.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.exposure_time.Name = "exposure_time";
            this.exposure_time.Size = new System.Drawing.Size(66, 21);
            this.exposure_time.TabIndex = 129;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 92);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(92, 12);
            this.label20.TabIndex = 130;
            this.label20.Text = "Exposure Time";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.Open_btn);
            this.groupBox3.Controls.Add(this.Baud_Combox);
            this.groupBox3.Controls.Add(this.exposure_time);
            this.groupBox3.Controls.Add(this.Close_btn);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.button_shutter_open);
            this.groupBox3.Controls.Add(this.Port_Combox);
            this.groupBox3.Controls.Add(this.button_shutter_close);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(684, 233);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(491, 127);
            this.groupBox3.TabIndex = 133;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Shutter";
            this.groupBox3.Visible = false;
            // 
            // Open_btn
            // 
            this.Open_btn.Location = new System.Drawing.Point(200, 25);
            this.Open_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Open_btn.Name = "Open_btn";
            this.Open_btn.Size = new System.Drawing.Size(79, 29);
            this.Open_btn.TabIndex = 138;
            this.Open_btn.Text = "Connect";
            this.Open_btn.UseVisualStyleBackColor = true;
            this.Open_btn.Click += new System.EventHandler(this.Open_btn_Click);
            // 
            // Close_btn
            // 
            this.Close_btn.Location = new System.Drawing.Point(285, 25);
            this.Close_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.Size = new System.Drawing.Size(94, 29);
            this.Close_btn.TabIndex = 139;
            this.Close_btn.Text = "Disconnect";
            this.Close_btn.UseVisualStyleBackColor = true;
            this.Close_btn.Click += new System.EventHandler(this.Close_btn_Click);
            // 
            // button_shutter_open
            // 
            this.button_shutter_open.Location = new System.Drawing.Point(200, 59);
            this.button_shutter_open.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_shutter_open.Name = "button_shutter_open";
            this.button_shutter_open.Size = new System.Drawing.Size(79, 29);
            this.button_shutter_open.TabIndex = 134;
            this.button_shutter_open.Text = "Open";
            this.button_shutter_open.UseVisualStyleBackColor = true;
            this.button_shutter_open.Click += new System.EventHandler(this.button_shutter_open_Click);
            // 
            // button_shutter_close
            // 
            this.button_shutter_close.Location = new System.Drawing.Point(285, 59);
            this.button_shutter_close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_shutter_close.Name = "button_shutter_close";
            this.button_shutter_close.Size = new System.Drawing.Size(94, 29);
            this.button_shutter_close.TabIndex = 135;
            this.button_shutter_close.Text = "Close";
            this.button_shutter_close.UseVisualStyleBackColor = true;
            this.button_shutter_close.Click += new System.EventHandler(this.button_shutter_close_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(385, 25);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 29);
            this.button1.TabIndex = 136;
            this.button1.Text = "One Shot";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mast_st_pnt
            // 
            this.mast_st_pnt.Location = new System.Drawing.Point(875, 115);
            this.mast_st_pnt.Name = "mast_st_pnt";
            this.mast_st_pnt.Size = new System.Drawing.Size(152, 32);
            this.mast_st_pnt.TabIndex = 145;
            this.mast_st_pnt.Text = "START POINT MOVE";
            this.mast_st_pnt.UseVisualStyleBackColor = true;
            this.mast_st_pnt.Visible = false;
            this.mast_st_pnt.Click += new System.EventHandler(this.mast_st_pnt_Click);
            // 
            // mast_pitch
            // 
            this.mast_pitch.DecimalPlaces = 3;
            this.mast_pitch.Location = new System.Drawing.Point(117, 51);
            this.mast_pitch.Maximum = new decimal(new int[] {
            298,
            0,
            0,
            0});
            this.mast_pitch.Name = "mast_pitch";
            this.mast_pitch.Size = new System.Drawing.Size(71, 21);
            this.mast_pitch.TabIndex = 144;
            // 
            // mast_start
            // 
            this.mast_start.DecimalPlaces = 3;
            this.mast_start.Location = new System.Drawing.Point(117, 27);
            this.mast_start.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.mast_start.Name = "mast_start";
            this.mast_start.Size = new System.Drawing.Size(71, 21);
            this.mast_start.TabIndex = 143;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(4, 53);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(81, 12);
            this.label24.TabIndex = 142;
            this.label24.Text = "Z Pitch (mm)";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(4, 30);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(110, 12);
            this.label25.TabIndex = 141;
            this.label25.Text = "Z Start Point (mm)";
            // 
            // lts_disscon
            // 
            this.lts_disscon.Location = new System.Drawing.Point(194, 39);
            this.lts_disscon.Name = "lts_disscon";
            this.lts_disscon.Size = new System.Drawing.Size(122, 21);
            this.lts_disscon.TabIndex = 150;
            this.lts_disscon.Text = "Z Disconnect";
            this.lts_disscon.UseVisualStyleBackColor = true;
            this.lts_disscon.Click += new System.EventHandler(this.lts_disscon_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(293, 53);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(90, 23);
            this.buttonHome.TabIndex = 151;
            this.buttonHome.Text = "Z Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // serialPort2
            // 
            this.serialPort2.PortName = "COM3";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(293, 27);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(90, 23);
            this.buttonStop.TabIndex = 163;
            this.buttonStop.Text = "Z Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(243, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 21);
            this.button2.TabIndex = 164;
            this.button2.Text = "Long Stage";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.long_stage_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(243, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 21);
            this.button3.TabIndex = 165;
            this.button3.Text = "Short Stage";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.short_stage_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(241, 27);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(91, 12);
            this.label27.TabIndex = 167;
            this.label27.Text = "(LIMIT 995mm)";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(241, 77);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(91, 12);
            this.label28.TabIndex = 166;
            this.label28.Text = "(LIMIT 995mm)";
            // 
            // one_step
            // 
            this.one_step.BackColor = System.Drawing.Color.Navy;
            this.one_step.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.one_step.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.one_step.Location = new System.Drawing.Point(89, 146);
            this.one_step.Name = "one_step";
            this.one_step.Size = new System.Drawing.Size(141, 33);
            this.one_step.TabIndex = 168;
            this.one_step.Text = "One Step";
            this.one_step.UseVisualStyleBackColor = false;
            this.one_step.Click += new System.EventHandler(this.one_step_Click);
            // 
            // full_step
            // 
            this.full_step.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.full_step.Location = new System.Drawing.Point(243, 146);
            this.full_step.Name = "full_step";
            this.full_step.Size = new System.Drawing.Size(139, 33);
            this.full_step.TabIndex = 169;
            this.full_step.Text = "All Step";
            this.full_step.UseVisualStyleBackColor = true;
            this.full_step.Click += new System.EventHandler(this.full_step_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label46);
            this.groupBox4.Controls.Add(this.label42);
            this.groupBox4.Controls.Add(this.z_pitch);
            this.groupBox4.Controls.Add(this.label41);
            this.groupBox4.Controls.Add(this.label40);
            this.groupBox4.Controls.Add(this.label39);
            this.groupBox4.Controls.Add(this.label38);
            this.groupBox4.Controls.Add(this.z_point_3);
            this.groupBox4.Controls.Add(this.z_point_2);
            this.groupBox4.Controls.Add(this.z_point_1);
            this.groupBox4.Controls.Add(this.label37);
            this.groupBox4.Controls.Add(this.on_delay);
            this.groupBox4.Controls.Add(this.label35);
            this.groupBox4.Controls.Add(this.off_dist);
            this.groupBox4.Controls.Add(this.direction_check);
            this.groupBox4.Controls.Add(this.label36);
            this.groupBox4.Controls.Add(this.scanning_count);
            this.groupBox4.Controls.Add(this.label34);
            this.groupBox4.Controls.Add(this.label33);
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Controls.Add(this.label31);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.lb_time);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.short_point_end);
            this.groupBox4.Controls.Add(this.short_point_0);
            this.groupBox4.Controls.Add(this.Setup_position);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.Long_point5);
            this.groupBox4.Controls.Add(this.Long_point4);
            this.groupBox4.Controls.Add(this.Long_point3);
            this.groupBox4.Controls.Add(this.Long_point2);
            this.groupBox4.Controls.Add(this.Long_point1);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.z_start_point);
            this.groupBox4.Controls.Add(this.buttonHome);
            this.groupBox4.Controls.Add(this.buttonStop);
            this.groupBox4.Controls.Add(this.one_step);
            this.groupBox4.Controls.Add(this.full_step);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.mast_start);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.mast_pitch);
            this.groupBox4.Location = new System.Drawing.Point(14, 366);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(875, 186);
            this.groupBox4.TabIndex = 170;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "WKU Setup";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label46.Location = new System.Drawing.Point(827, 107);
            this.label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(31, 25);
            this.label46.TabIndex = 205;
            this.label46.Text = "초";
            this.label46.Visible = false;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(425, 124);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(41, 12);
            this.label42.TabIndex = 204;
            this.label42.Text = "Pitch :";
            // 
            // z_pitch
            // 
            this.z_pitch.DecimalPlaces = 3;
            this.z_pitch.Location = new System.Drawing.Point(474, 120);
            this.z_pitch.Maximum = new decimal(new int[] {
            298,
            0,
            0,
            0});
            this.z_pitch.Name = "z_pitch";
            this.z_pitch.Size = new System.Drawing.Size(71, 21);
            this.z_pitch.TabIndex = 201;
            this.z_pitch.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(425, 27);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(81, 12);
            this.label41.TabIndex = 203;
            this.label41.Text = "Z Stage Point";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(425, 77);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(47, 12);
            this.label40.TabIndex = 202;
            this.label40.Text = "Point2 :";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(425, 100);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(47, 12);
            this.label39.TabIndex = 201;
            this.label39.Text = "Point3 :";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(425, 53);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(47, 12);
            this.label38.TabIndex = 181;
            this.label38.Text = "Point1 :";
            // 
            // z_point_3
            // 
            this.z_point_3.DecimalPlaces = 3;
            this.z_point_3.Location = new System.Drawing.Point(474, 97);
            this.z_point_3.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.z_point_3.Name = "z_point_3";
            this.z_point_3.Size = new System.Drawing.Size(71, 21);
            this.z_point_3.TabIndex = 200;
            this.z_point_3.Value = new decimal(new int[] {
            285,
            0,
            0,
            0});
            // 
            // z_point_2
            // 
            this.z_point_2.DecimalPlaces = 3;
            this.z_point_2.Location = new System.Drawing.Point(474, 74);
            this.z_point_2.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.z_point_2.Name = "z_point_2";
            this.z_point_2.Size = new System.Drawing.Size(71, 21);
            this.z_point_2.TabIndex = 199;
            this.z_point_2.Value = new decimal(new int[] {
            285,
            0,
            0,
            0});
            // 
            // z_point_1
            // 
            this.z_point_1.DecimalPlaces = 3;
            this.z_point_1.Location = new System.Drawing.Point(474, 51);
            this.z_point_1.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.z_point_1.Name = "z_point_1";
            this.z_point_1.Size = new System.Drawing.Size(71, 21);
            this.z_point_1.TabIndex = 198;
            this.z_point_1.Value = new decimal(new int[] {
            285,
            0,
            0,
            0});
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(707, 167);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(100, 12);
            this.label37.TabIndex = 197;
            this.label37.Text = "Shutter On Delay";
            this.label37.Visible = false;
            // 
            // on_delay
            // 
            this.on_delay.DecimalPlaces = 1;
            this.on_delay.Location = new System.Drawing.Point(824, 162);
            this.on_delay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.on_delay.Name = "on_delay";
            this.on_delay.Size = new System.Drawing.Size(65, 21);
            this.on_delay.TabIndex = 196;
            this.on_delay.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.on_delay.Visible = false;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(707, 187);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(116, 12);
            this.label35.TabIndex = 195;
            this.label35.Text = "Shutter Off Distance";
            this.label35.Visible = false;
            // 
            // off_dist
            // 
            this.off_dist.DecimalPlaces = 3;
            this.off_dist.Location = new System.Drawing.Point(824, 184);
            this.off_dist.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.off_dist.Name = "off_dist";
            this.off_dist.Size = new System.Drawing.Size(65, 21);
            this.off_dist.TabIndex = 194;
            this.off_dist.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.off_dist.Visible = false;
            // 
            // direction_check
            // 
            this.direction_check.AutoSize = true;
            this.direction_check.Location = new System.Drawing.Point(6, 107);
            this.direction_check.Name = "direction_check";
            this.direction_check.Size = new System.Drawing.Size(100, 16);
            this.direction_check.TabIndex = 168;
            this.direction_check.Text = "One Direction";
            this.direction_check.UseVisualStyleBackColor = true;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label36.ForeColor = System.Drawing.Color.Red;
            this.label36.Location = new System.Drawing.Point(4, 80);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(109, 12);
            this.label36.TabIndex = 193;
            this.label36.Text = "Scanning Count";
            // 
            // scanning_count
            // 
            this.scanning_count.Location = new System.Drawing.Point(145, 75);
            this.scanning_count.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.scanning_count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scanning_count.Name = "scanning_count";
            this.scanning_count.Size = new System.Drawing.Size(43, 21);
            this.scanning_count.TabIndex = 191;
            this.scanning_count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(705, 76);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(47, 12);
            this.label34.TabIndex = 190;
            this.label34.Text = "Point2 :";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(705, 53);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(47, 12);
            this.label33.TabIndex = 188;
            this.label33.Text = "Point1 :";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(573, 99);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(47, 12);
            this.label32.TabIndex = 189;
            this.label32.Text = "Point3 :";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(573, 76);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(47, 12);
            this.label31.TabIndex = 188;
            this.label31.Text = "Point2 :";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(573, 52);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(47, 12);
            this.label30.TabIndex = 187;
            this.label30.Text = "Point1 :";
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_time.Location = new System.Drawing.Point(778, 104);
            this.lb_time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(22, 25);
            this.lb_time.TabIndex = 186;
            this.lb_time.Text = "0";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(705, 111);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 12);
            this.label26.TabIndex = 185;
            this.label26.Text = "실행 시간 :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(705, 27);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(102, 12);
            this.label23.TabIndex = 184;
            this.label23.Text = "Short Stage Point";
            // 
            // short_point_end
            // 
            this.short_point_end.DecimalPlaces = 3;
            this.short_point_end.Location = new System.Drawing.Point(754, 73);
            this.short_point_end.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.short_point_end.Name = "short_point_end";
            this.short_point_end.Size = new System.Drawing.Size(65, 21);
            this.short_point_end.TabIndex = 203;
            this.short_point_end.Value = new decimal(new int[] {
            710,
            0,
            0,
            0});
            // 
            // short_point_0
            // 
            this.short_point_0.DecimalPlaces = 3;
            this.short_point_0.Location = new System.Drawing.Point(754, 49);
            this.short_point_0.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.short_point_0.Name = "short_point_0";
            this.short_point_0.Size = new System.Drawing.Size(65, 21);
            this.short_point_0.TabIndex = 202;
            this.short_point_0.Value = new decimal(new int[] {
            390,
            0,
            0,
            0});
            // 
            // Setup_position
            // 
            this.Setup_position.BackColor = System.Drawing.Color.Maroon;
            this.Setup_position.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Setup_position.ForeColor = System.Drawing.Color.LavenderBlush;
            this.Setup_position.Location = new System.Drawing.Point(243, 107);
            this.Setup_position.Name = "Setup_position";
            this.Setup_position.Size = new System.Drawing.Size(139, 33);
            this.Setup_position.TabIndex = 181;
            this.Setup_position.Text = "Setup Position";
            this.Setup_position.UseVisualStyleBackColor = false;
            this.Setup_position.Click += new System.EventHandler(this.setup_position_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(575, 27);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(101, 12);
            this.label29.TabIndex = 179;
            this.label29.Text = "Long Stage Point";
            // 
            // Long_point5
            // 
            this.Long_point5.DecimalPlaces = 3;
            this.Long_point5.Location = new System.Drawing.Point(620, 144);
            this.Long_point5.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Long_point5.Name = "Long_point5";
            this.Long_point5.Size = new System.Drawing.Size(65, 21);
            this.Long_point5.TabIndex = 178;
            this.Long_point5.Visible = false;
            // 
            // Long_point4
            // 
            this.Long_point4.DecimalPlaces = 3;
            this.Long_point4.Location = new System.Drawing.Point(620, 121);
            this.Long_point4.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Long_point4.Name = "Long_point4";
            this.Long_point4.Size = new System.Drawing.Size(65, 21);
            this.Long_point4.TabIndex = 177;
            this.Long_point4.Value = new decimal(new int[] {
            980,
            0,
            0,
            0});
            this.Long_point4.Visible = false;
            // 
            // Long_point3
            // 
            this.Long_point3.DecimalPlaces = 3;
            this.Long_point3.Location = new System.Drawing.Point(620, 97);
            this.Long_point3.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Long_point3.Name = "Long_point3";
            this.Long_point3.Size = new System.Drawing.Size(65, 21);
            this.Long_point3.TabIndex = 176;
            this.Long_point3.Value = new decimal(new int[] {
            750,
            0,
            0,
            0});
            // 
            // Long_point2
            // 
            this.Long_point2.DecimalPlaces = 3;
            this.Long_point2.Location = new System.Drawing.Point(620, 73);
            this.Long_point2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Long_point2.Name = "Long_point2";
            this.Long_point2.Size = new System.Drawing.Size(65, 21);
            this.Long_point2.TabIndex = 175;
            this.Long_point2.Value = new decimal(new int[] {
            450,
            0,
            0,
            0});
            // 
            // Long_point1
            // 
            this.Long_point1.DecimalPlaces = 3;
            this.Long_point1.Location = new System.Drawing.Point(620, 49);
            this.Long_point1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Long_point1.Name = "Long_point1";
            this.Long_point1.Size = new System.Drawing.Size(65, 21);
            this.Long_point1.TabIndex = 174;
            this.Long_point1.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(197, 53);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 23);
            this.button4.TabIndex = 171;
            this.button4.Text = "Pitch Move";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.pitch_move_Click);
            // 
            // z_start_point
            // 
            this.z_start_point.Location = new System.Drawing.Point(197, 27);
            this.z_start_point.Name = "z_start_point";
            this.z_start_point.Size = new System.Drawing.Size(90, 23);
            this.z_start_point.TabIndex = 171;
            this.z_start_point.Text = "Z Start Point";
            this.z_start_point.UseVisualStyleBackColor = true;
            this.z_start_point.Click += new System.EventHandler(this.z_start_point_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 85);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 12);
            this.label17.TabIndex = 173;
            this.label17.Text = "Z Stage Speed";
            // 
            // z_stg_spd
            // 
            this.z_stg_spd.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.z_stg_spd.Location = new System.Drawing.Point(129, 83);
            this.z_stg_spd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.z_stg_spd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.z_stg_spd.Name = "z_stg_spd";
            this.z_stg_spd.Size = new System.Drawing.Size(59, 21);
            this.z_stg_spd.TabIndex = 206;
            this.z_stg_spd.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(817, 49);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 12);
            this.label16.TabIndex = 171;
            this.label16.Text = "기록 횟수";
            this.label16.Visible = false;
            // 
            // counting_num
            // 
            this.counting_num.Location = new System.Drawing.Point(882, 43);
            this.counting_num.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.counting_num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.counting_num.Name = "counting_num";
            this.counting_num.Size = new System.Drawing.Size(71, 21);
            this.counting_num.TabIndex = 170;
            this.counting_num.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.counting_num.Visible = false;
            // 
            // move_stop
            // 
            this.move_stop.Location = new System.Drawing.Point(932, 160);
            this.move_stop.Name = "move_stop";
            this.move_stop.Size = new System.Drawing.Size(88, 23);
            this.move_stop.TabIndex = 109;
            this.move_stop.Text = "move_stop";
            this.move_stop.UseVisualStyleBackColor = true;
            this.move_stop.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.pitch_val_x);
            this.groupBox5.Controls.Add(this.str_pt_x);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.str_pt_y);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.pitch_val_y);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Location = new System.Drawing.Point(275, 82);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(355, 139);
            this.groupBox5.TabIndex = 174;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "XY Stage Move";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.long_spd);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.MOTOR_SPEED);
            this.groupBox6.Controls.Add(this.short_spd);
            this.groupBox6.Controls.Add(this.spd_set);
            this.groupBox6.Controls.Add(this.z_stg_spd);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Location = new System.Drawing.Point(275, 227);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(371, 127);
            this.groupBox6.TabIndex = 180;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Speed Setup";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(191, 62);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 12);
            this.label21.TabIndex = 178;
            this.label21.Text = "(Limit 1~1000)";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 61);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(109, 12);
            this.label22.TabIndex = 176;
            this.label22.Text = "Long Stage Speed";
            // 
            // long_spd
            // 
            this.long_spd.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.long_spd.Location = new System.Drawing.Point(129, 58);
            this.long_spd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.long_spd.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.long_spd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.long_spd.Name = "long_spd";
            this.long_spd.Size = new System.Drawing.Size(59, 21);
            this.long_spd.TabIndex = 205;
            this.long_spd.Value = new decimal(new int[] {
            650,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(191, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 12);
            this.label6.TabIndex = 175;
            this.label6.Text = "(Limit 1~90)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 12);
            this.label5.TabIndex = 174;
            this.label5.Text = "(Limit 1~1000)";
            // 
            // thorlabs_sh_connect
            // 
            this.thorlabs_sh_connect.Location = new System.Drawing.Point(117, 39);
            this.thorlabs_sh_connect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.thorlabs_sh_connect.Name = "thorlabs_sh_connect";
            this.thorlabs_sh_connect.Size = new System.Drawing.Size(116, 20);
            this.thorlabs_sh_connect.TabIndex = 181;
            this.thorlabs_sh_connect.Text = "Shutter Connect";
            this.thorlabs_sh_connect.UseVisualStyleBackColor = true;
            this.thorlabs_sh_connect.Click += new System.EventHandler(this.thorlabs_sh_connect_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button5);
            this.groupBox7.Controls.Add(this.comboBox1);
            this.groupBox7.Controls.Add(this.textBox2);
            this.groupBox7.Controls.Add(this.thorlabs_sh_connect);
            this.groupBox7.Location = new System.Drawing.Point(14, 227);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(249, 127);
            this.groupBox7.TabIndex = 182;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Thorlabs Shutter";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 71);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(97, 32);
            this.textBox2.TabIndex = 189;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(549, 52);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(68, 12);
            this.label45.TabIndex = 188;
            this.label45.Text = "End Time :";
            this.label45.Visible = false;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(549, 30);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(71, 12);
            this.label44.TabIndex = 187;
            this.label44.Text = "Start Time :";
            this.label44.Visible = false;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DecimalPlaces = 2;
            this.numericUpDown3.Location = new System.Drawing.Point(652, 48);
            this.numericUpDown3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(59, 21);
            this.numericUpDown3.TabIndex = 186;
            this.numericUpDown3.Visible = false;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 2;
            this.numericUpDown2.Location = new System.Drawing.Point(652, 26);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(59, 21);
            this.numericUpDown2.TabIndex = 185;
            this.numericUpDown2.Visible = false;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(549, 9);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(100, 12);
            this.label43.TabIndex = 184;
            this.label43.Text = "Exposure Time :";
            this.label43.Visible = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Location = new System.Drawing.Point(652, 4);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(59, 21);
            this.numericUpDown1.TabIndex = 183;
            this.numericUpDown1.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(97, 20);
            this.comboBox1.TabIndex = 190;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(117, 71);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(116, 32);
            this.button5.TabIndex = 191;
            this.button5.Text = "Open/Close";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 574);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.move_stop);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lts_disscon);
            this.Controls.Add(this.mast_st_pnt);
            this.Controls.Add(this.start_point);
            this.Controls.Add(this.stage_move);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.counting_num);
            this.Controls.Add(this.y_array);
            this.Controls.Add(this.x_array);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.stg_dis);
            this.Controls.Add(this.stg_con);
            this.Name = "Form1";
            this.Text = "XY_Stage_WKU";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.short_spd)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pitch_val_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.str_pt_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.str_pt_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitch_val_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_array)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_array)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exposure_time)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mast_pitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mast_start)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.z_pitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_point_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_point_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_point_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.on_delay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.off_dist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scanning_count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.short_point_end)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.short_point_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Long_point5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Long_point4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Long_point3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Long_point2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Long_point1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_stg_spd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.counting_num)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.long_spd)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button spd_set;
        private System.Windows.Forms.NumericUpDown short_spd;
        private System.Windows.Forms.Label MOTOR_SPEED;
        private System.Windows.Forms.Button stg_dis;
        private System.Windows.Forms.Button stg_con;
        private System.Windows.Forms.Button error_reset;
        private System.Windows.Forms.Button rebot_controller;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_x_position;
        private System.Windows.Forms.Label lb_y_position;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button sv_off;
        private System.Windows.Forms.Button sv_on;
        private System.Windows.Forms.Button posi_chk;
        private System.Windows.Forms.Button origin;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button long_right;
        private System.Windows.Forms.Button short_left;
        private System.Windows.Forms.Button short_right;
        private System.Windows.Forms.Button start_point;
        private System.Windows.Forms.Button stage_move;
        private System.Windows.Forms.NumericUpDown pitch_val_y;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown str_pt_y;
        private System.Windows.Forms.NumericUpDown str_pt_x;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown pitch_val_x;
        private System.Windows.Forms.NumericUpDown y_array;
        private System.Windows.Forms.NumericUpDown x_array;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox Baud_Combox;
        private System.Windows.Forms.ComboBox Port_Combox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown exposure_time;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button_shutter_open;
        private System.Windows.Forms.Button button_shutter_close;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Open_btn;
        private System.Windows.Forms.Button Close_btn;
        private System.Windows.Forms.Button mast_st_pnt;
        private System.Windows.Forms.NumericUpDown mast_pitch;
        private System.Windows.Forms.NumericUpDown mast_start;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button lts_disscon;
        private System.Windows.Forms.Button buttonHome;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button one_step;
        private System.Windows.Forms.Button full_step;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown counting_num;
        private System.Windows.Forms.Button z_start_point;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown z_stg_spd;
        private System.Windows.Forms.Button move_stop;
        private System.Windows.Forms.Button long_left;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.NumericUpDown Long_point5;
        private System.Windows.Forms.NumericUpDown Long_point4;
        private System.Windows.Forms.NumericUpDown Long_point3;
        private System.Windows.Forms.NumericUpDown Long_point2;
        private System.Windows.Forms.NumericUpDown Long_point1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown long_spd;
        private System.Windows.Forms.Button Setup_position;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown short_point_end;
        private System.Windows.Forms.NumericUpDown short_point_0;
        private System.Windows.Forms.Label lb_time;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.NumericUpDown scanning_count;
        private System.Windows.Forms.CheckBox direction_check;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.NumericUpDown off_dist;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.NumericUpDown on_delay;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.NumericUpDown z_point_3;
        private System.Windows.Forms.NumericUpDown z_point_2;
        private System.Windows.Forms.NumericUpDown z_point_1;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.NumericUpDown z_pitch;
        private System.Windows.Forms.Button thorlabs_sh_connect;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button5;
    }
}

