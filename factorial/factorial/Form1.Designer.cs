namespace factorial;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new Label();
        textBox1 = new TextBox();
        button1 = new Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(40, 26);
        label1.Name = "label1";
        label1.Size = new Size(114, 15);
        label1.TabIndex = 0;
        label1.Text = "Escriba un  Número ";
        label1.Click += label1_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(185, 23);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(100, 23);
        textBox1.TabIndex = 1;
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // button1
        // 
        button1.Location = new Point(78, 71);
        button1.Name = "button1";
        button1.Size = new Size(137, 40);
        button1.TabIndex = 2;
        button1.Text = "Calcular Factorial";
        button1.UseVisualStyleBackColor = true;
        
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        
        Controls.Add(button1);
        Controls.Add(textBox1);
        Controls.Add(label1);
        
        this.Text = "Form1";
    }

    private Label label1;
    private TextBox textBox1;
    private Button button1;

    #endregion
}