﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace DiceRoller
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void DisplayOne(object sender, EventArgs e)
        {
            Result2.IsVisible = false;
            int numberSide = getNumberSide();

            Die d1 = new Die(numberSide);
            Result1.Text = d1.CurrentSide.ToString();
        }

        public void DisplayTwo(object sender, EventArgs e)
        {
            Result2.IsVisible = true;

            int numberSide = getNumberSide();

            Die d1 = new Die(numberSide);
            Die d2 = new Die(numberSide);

            Result1.Text = d1.CurrentSide.ToString();
            Result2.Text = d2.CurrentSide.ToString();
        }

        public int getNumberSide()
        {
            int numberSide = 0;

            if (d4.IsChecked)
                numberSide = Int32.Parse(d4.Value.ToString());

            else if (d6.IsChecked)
                numberSide = Int32.Parse(d6.Value.ToString());

            else if (d8.IsChecked)
                numberSide = Int32.Parse(d8.Value.ToString());

            else if (d10.IsChecked)
                numberSide = Int32.Parse(d10.Value.ToString());

            else if (d12.IsChecked)
                numberSide = Int32.Parse(d12.Value.ToString());

            else if (d20.IsChecked)
                numberSide = Int32.Parse(d20.Value.ToString());

            return numberSide;
        }
    }
}

