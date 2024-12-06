using System.ComponentModel;

namespace MoviesFE.Views;

partial class MovieEditForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.releaseDateTimePicker = new System.Windows.Forms.DateTimePicker();
        this.confirmButton = new System.Windows.Forms.Button();
        this.cancelButton = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.titleTextBox = new System.Windows.Forms.TextBox();
        this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
        this.SuspendLayout();
        // 
        // releaseDateTimePicker
        // 
        this.releaseDateTimePicker.Location = new System.Drawing.Point(105, 32);
        this.releaseDateTimePicker.Name = "releaseDateTimePicker";
        this.releaseDateTimePicker.Size = new System.Drawing.Size(301, 20);
        this.releaseDateTimePicker.TabIndex = 0;
        // 
        // confirmButton
        // 
        this.confirmButton.Location = new System.Drawing.Point(250, 190);
        this.confirmButton.Name = "confirmButton";
        this.confirmButton.Size = new System.Drawing.Size(75, 23);
        this.confirmButton.TabIndex = 1;
        this.confirmButton.Text = "Confirm";
        this.confirmButton.UseVisualStyleBackColor = true;
        // 
        // cancelButton
        // 
        this.cancelButton.Location = new System.Drawing.Point(331, 190);
        this.cancelButton.Name = "cancelButton";
        this.cancelButton.Size = new System.Drawing.Size(75, 23);
        this.cancelButton.TabIndex = 2;
        this.cancelButton.Text = "Cancel";
        this.cancelButton.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        this.label1.Location = new System.Drawing.Point(12, 9);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(33, 20);
        this.label1.TabIndex = 3;
        this.label1.Text = "Title:";
        // 
        // label2
        // 
        this.label2.Location = new System.Drawing.Point(12, 32);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(76, 20);
        this.label2.TabIndex = 4;
        this.label2.Text = "Release date:";
        // 
        // label3
        // 
        this.label3.Location = new System.Drawing.Point(12, 58);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(76, 20);
        this.label3.TabIndex = 5;
        this.label3.Text = "Description:";
        // 
        // titleTextBox
        // 
        this.titleTextBox.Location = new System.Drawing.Point(105, 6);
        this.titleTextBox.Name = "titleTextBox";
        this.titleTextBox.Size = new System.Drawing.Size(301, 20);
        this.titleTextBox.TabIndex = 6;
        // 
        // descriptionTextBox
        // 
        this.descriptionTextBox.Location = new System.Drawing.Point(105, 58);
        this.descriptionTextBox.Name = "descriptionTextBox";
        this.descriptionTextBox.Size = new System.Drawing.Size(301, 96);
        this.descriptionTextBox.TabIndex = 7;
        this.descriptionTextBox.Text = "";
        // 
        // MovieEditForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(418, 225);
        this.ControlBox = false;
        this.Controls.Add(this.descriptionTextBox);
        this.Controls.Add(this.titleTextBox);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.cancelButton);
        this.Controls.Add(this.confirmButton);
        this.Controls.Add(this.releaseDateTimePicker);
        this.Name = "MovieEditForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Movie";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    public System.Windows.Forms.DateTimePicker releaseDateTimePicker;
    public System.Windows.Forms.Button confirmButton;
    public System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    public System.Windows.Forms.TextBox titleTextBox;
    public System.Windows.Forms.RichTextBox descriptionTextBox;

    #endregion
}

