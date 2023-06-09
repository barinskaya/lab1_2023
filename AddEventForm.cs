﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace organizer
{
    public partial class AddEventForm : Form
    {
        public Organizer organizer;
        public AddEventForm()
        {
            InitializeComponent();
        }

        public void setOrganize(ref Organizer organizer)
        {
            this.organizer = organizer;
        }

        private void AddEventForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(EventType.MEETING.ToString());
            comboBox1.Items.Add(EventType.TASK.ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DateTime.Now.Ticks > monthCalendar1.SelectionStart.Ticks)
            {
                MessageBox.Show("Данная дата уже прошла");
                return;
            }
            organizer.add(new Data(
                textBox1.Text,
                monthCalendar1.SelectionStart,
                dateTimePicker1.Value.TimeOfDay,
                (EventType)Enum.Parse(typeof(EventType),
                comboBox1.Text, true)


                ));
            this.Hide();
        }
    }
}
