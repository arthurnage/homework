/* Copyright 2015-2016 Research Group
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.

 ░░░░░░░░░░░▀▄░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░▀▄░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░▄▄█▄▄▄▄▄▄▄▄░░░░░░░░░░░░░░
░░░░░░░░▄▄█▀▀▀▀▀░░░░░▀▀▀███▄▄░░░░░░░░░
░░░░░░▄█▀░░░░░░░░░░░░░░░░░░▀▀██▄░░░░░░
░░░░▄▀░░░░░░░░░░░░░░░░░░░░░░░░██░░░░░░
░░▄▄█░░░░░░░░░░░░░▄▄█████▄░░░░░█▄▄░░░░
▄█▀▀░▄▀▀▀██▄░░░░░▀▀░▄████▀▀▀░░░▀▀▀██▄░
█▀░░░░░▄▄████░░░░░█▀▀░░▄▄░░░░░░░░░░▀█▄
█▄░░░░░░░░░▀█░░░░░░░░░▀▀▀░░░░░░░░░░░██
▀█▄░░███░░▄█▄▄░▀░░▄▄░░░░▀▀░░░░░░░░░▄█▀
░▀▀█░░░░░▄░░░░░░░░▄▄▄███░░░░░░░░▄▄▄█▀░
░░░█░░░░████▀█▀████████░▀░░░░░▄█▀▀▀░░░
░░░█░░░░█████████▀▄██▀░░░░░░▄█▀░░░░░░░
░░░█▄░░░░███████▀▀▀░░░░░░▄▄█▀░░░░░░░░░
░░░██▄░░░░░▀▀░░░░░░░░▄▄██▀░░░░░░░░░░░░
░░░░▀▀██▄▄▄▄▄▄▄▄▄▄██▀▀▀░░░░░░░░░░░░░░░
░░░░░░░░░▀▀▀▀▀▀▀░░░░░░░░░░░░░░░░░░░░░░
*/



using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace _1
{
    public partial class MainPage : UserControl
    {
        /// <summary>
		/// The counter of steps of game
		/// </summary>
		private static int steps;

        /// <summary>
        /// The button array.
        /// </summary>
        private static Button[] buttonArray;

        /// <summary>
        /// The player array.
        /// </summary>
        private static List<int> playerArray;

        /// <summary>
        /// The bot array.
        /// </summary>
        private static List<int> botArray;

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public MainPage()
        {
            InitializeComponent();
            botArray = new List<int>();
            playerArray = new List<int>();
            buttonArray = new Button[9];
            this.Name = "Game";

            buttonArray[0] = button1;
            buttonArray[1] = button2;
            buttonArray[2] = button3;
            buttonArray[3] = button4;
            buttonArray[4] = button5;
            buttonArray[5] = button6;
            buttonArray[6] = button7;
            buttonArray[7] = button8;
            buttonArray[8] = button9;
           
            // set special values in button (magic triangle)
			buttonArray[0].Tag = 2;
			buttonArray[1].Tag = 7;
			buttonArray[2].Tag = 6;
			buttonArray[3].Tag = 9;
			buttonArray[4].Tag = 5;
			buttonArray[5].Tag = 1;
			buttonArray[6].Tag = 4;
			buttonArray[7].Tag = 3;
			buttonArray[8].Tag = 8;
            
            Button newGameButton = button;
        }

        /// <summary>
        /// Raises the button clicked event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        internal void OnButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button.IsEnabled)
            {
                button.Content = "X";
                button.IsEnabled = false;
                playerArray.Add(Convert.ToInt32(button.Tag));
                steps++;
                if (WinCheck(playerArray))
                {
                    resultButton.Content = "You won!";
                    return;
                }
                MakeBotStep();
                if (WinCheck(botArray))
                {
                    resultButton.Content = "Bot won";
                    return;
                }
                if (steps == 9)
                {
                    resultButton.Content = "Draw a game";
                    return;
                }
            }
        }

        /// <summary>
        /// Starts a new game.
        /// </summary>
        internal void NewGame(object sender, EventArgs e)
        {
            botArray.Clear();
            playerArray.Clear();
            resultButton.Content = "";
            foreach (var button in buttonArray)
            {
                button.Content = "";
                button.IsEnabled = true;
            }
            steps = 0;
        }

        /// <summary>
        /// check the result of game
        /// </summary>
        /// <returns><c>true</c>, if check was windowed, <c>false</c> otherwise.</returns>
        /// <param name="array">Array.</param>
        private static bool WinCheck(List<int> array)
        {
            if (array.Count >= 3)
            {
                for (int i = 0; i < array.Count - 2; ++i)
                {
                    for (int j = i + 1; j < array.Count - 1; ++j)
                    {
                        for (int k = j + 1; k < array.Count; ++k)
                        {
                            if (array[i] + array[j] + array[k] == 15)
                            {
                                for (int t = 0; t < 9; ++t)
                                {
                                    buttonArray[t].IsEnabled = false;
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Makes the bot step.
        /// </summary>
        public static void MakeBotStep()
        {
            if (steps == 1)
            {
                if (buttonArray[4].IsEnabled)
                {
                    buttonArray[4].Content = "O";
                    buttonArray[4].IsEnabled = false;
                    botArray.Add(Convert.ToInt32(buttonArray[4].Tag));
                }
                else
                {
                    buttonArray[0].Content = "O";
                    buttonArray[0].IsEnabled = false;
                    botArray.Add(Convert.ToInt32(buttonArray[0].Tag));
                }
                steps++;
            }
            else
            {
                for (int i = 0; i < botArray.Count - 1; ++i)
                {
                    for (int j = i + 1; j < botArray.Count; ++j)
                    {
                        int currentValue = 15 - botArray[i] - botArray[j];
                        for (int k = 0; k < 9; ++k)
                        {
                            if (Convert.ToInt32(buttonArray[k].Tag) == currentValue && buttonArray[k].IsEnabled)
                            {
                                buttonArray[k].Content = "O";
                                buttonArray[k].IsEnabled = false;
                                steps++;
                                botArray.Add(Convert.ToInt32(buttonArray[k].Tag));
                                return;
                            }
                        }
                    }
                }
                for (int i = 0; i < playerArray.Count - 1; ++i)
                {
                    for (int j = i + 1; j < playerArray.Count; ++j)
                    {
                        int currentValue = 15 - playerArray[i] - playerArray[j];
                        for (int k = 0; k < 9; ++k)
                        {
                            if (Convert.ToInt32(buttonArray[k].Tag) == currentValue && buttonArray[k].IsEnabled)
                            {
                                buttonArray[k].Content = "O";
                                buttonArray[k].IsEnabled = false;
                                steps++;
                                botArray.Add(Convert.ToInt32(buttonArray[k].Tag));
                                return;
                            }
                        }
                    }
                }
                for (int k = 0; k < 9; ++k)
                {
                    if (buttonArray[k].IsEnabled)
                    {
                        buttonArray[k].Content = "O";
                        buttonArray[k].IsEnabled = false;
                        steps++;
                        botArray.Add(Convert.ToInt32(buttonArray[k].Tag));
                        return;
                    }
                }
            }
        }
    }
}
