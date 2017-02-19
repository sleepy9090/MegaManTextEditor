using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MegaManTextEditor
{
    class Backend
    {
        int textFlag = 0;

        public Backend()
        {

        }

        public void getText(string path, TextBox texboxname, int length, int offset, int tableToUse)
        {
            string romCodeString = "";
            string megaManAsciiOut = "";
            string tempHexString = "";
            int x = 0;
            using (FileStream fileStream = new FileStream(@path, FileMode.Open, FileAccess.Read))
            {

                fileStream.Seek(offset, SeekOrigin.Begin);

                while (x < length)
                {
                    romCodeString = fileStream.ReadByte().ToString("X");
                    //if length is single digit add a 0 ( 1 now is 01)
                    if (romCodeString.Length == 1)
                    {
                        romCodeString = "0" + romCodeString;
                    }
                    tempHexString = romCodeString;

                    if (tableToUse == 1)
                    {
                        decodeRomText1(tempHexString);
                    }
                    else if (tableToUse == 2)
                    {
                        decodeRomText2(tempHexString);
                    } 
                    else if (tableToUse == 3)
                    {
                        decodeRomText3(tempHexString);
                    } 
                    else // just use table 1
                    {
                        decodeRomText1(tempHexString);
                    }
                    
                    if (textFlag == 0)
                    {
                        if (tableToUse == 1)
                        {
                            megaManAsciiOut += decodeRomText1(tempHexString);
                        }
                        else if (tableToUse == 2)
                        {
                            megaManAsciiOut += decodeRomText2(tempHexString);
                        }
                        else if (tableToUse == 3)
                        {
                            megaManAsciiOut += decodeRomText3(tempHexString);
                        } 
                        else // just use table 1
                        {
                            megaManAsciiOut += decodeRomText1(tempHexString);
                        }
                    }
                    x++;

                    texboxname.Text = megaManAsciiOut;
                }
            }
        }

        public void updateROMText(string absoluteFilename, int length, TextBox textBox, int offset, int tableToUse)
        {
            // TODO: Optimize, all of these steps are unneccesary
            string newICString = textBox.Text;
            newICString = newICString.PadRight(length);
            string hexReturn = "";
            string tempascii = "";
            string[] newICStringArray = new string[length];
            byte[] newICStringByteArray = new byte[length];
            int[] icDecimal = new int[length];
            string[] icFinal = new string[length];
            string[] ics = new string[length];

            int x = 0;
            while (x < length)
            {
                newICStringArray[x] = newICString[x].ToString();
                tempascii = newICStringArray[x];
                if (tableToUse == 1)
                {
                    hexReturn += encodeRomText1(tempascii);
                }
                else if (tableToUse == 2)
                {
                    hexReturn += encodeRomText2(tempascii);
                }
                else if (tableToUse == 3) 
                {
                    hexReturn += encodeRomText3(tempascii);
                }
                else // just use table 1
                {
                    hexReturn += encodeRomText1(tempascii);
                }
                x++;
            }

            int i = 0;
            int j = 0;
            while (i < length)
            {
                ics[i] = hexReturn[j].ToString() + hexReturn[j + 1].ToString();
                i++;
                j += 2;
            }

            int q = 0;
            while (q < length)
            {
                icDecimal[q] = int.Parse(ics[q], System.Globalization.NumberStyles.HexNumber);
                icFinal[q] = icDecimal[q].ToString();
                newICStringByteArray[q] = byte.Parse(icFinal[q]);
                q++;
            }

            using (FileStream fileStream = new FileStream(@absoluteFilename, FileMode.Open, FileAccess.Write))
            {
                fileStream.Seek(offset, SeekOrigin.Begin);
                q = 0;
                while (q < length)
                {
                    fileStream.WriteByte(newICStringByteArray[q]);
                    q++;
                }
            }
        }

        // stage select, stage clear, 
        private string decodeRomText1(string tempHexString)
        {
            string megamanAscii = "";
            textFlag = 0;

            switch (tempHexString)
            {
                case "01":
                    megamanAscii += "A";
                    break;
                case "02":
                    megamanAscii += "B";
                    break;
                case "03":
                    megamanAscii += "C";
                    break;
                case "04":
                    megamanAscii += "D";
                    break;
                case "05":
                    megamanAscii += "E";
                    break;
                case "06":
                    megamanAscii += "F";
                    break;
                case "07":
                    megamanAscii += "G";
                    break;
                case "08":
                    megamanAscii += "H";
                    break;
                case "09":
                    megamanAscii += "I";
                    break;
                case "0A":
                    megamanAscii += "J";
                    break;
                case "0B":
                    megamanAscii += "K";
                    break;
                case "0C":
                    megamanAscii += "L";
                    break;
                case "0D":
                    megamanAscii += "M";
                    break;
                case "0E":
                    megamanAscii += "N";
                    break;
                case "0F":
                    megamanAscii += "O";
                    break;
                case "10":
                    megamanAscii += "P";
                    break;
                case "11":
                    megamanAscii += "O";
                    break;
                case "12":
                    megamanAscii += "R";
                    break;
                case "13":
                    megamanAscii += "S";
                    break;
                case "14":
                    megamanAscii += "T";
                    break;
                case "15":
                    megamanAscii += "U";
                    break;
                case "16":
                    megamanAscii += "V";
                    break;
                case "17":
                    megamanAscii += "W";
                    break;
                case "018":
                    megamanAscii += "X";
                    break;
                case "19":
                    megamanAscii += "Y";
                    break;
                case "1A":
                    megamanAscii += "Z";
                    break;
                case "1B": // SPECIAL CASE (r.) Find a single letter to represent the "r.", we will repesent that with a hat ^
                    //megamanAscii += "r.";
                    megamanAscii += "^";
                    break;
                case "1C":
                    megamanAscii += ".";
                    break;
                case "1D":
                    megamanAscii += ",";
                    break;
                case "1E":
                    megamanAscii += "'";
                    break;
                case "1F":
                    megamanAscii += "!";
                    break;
                case "20":
                    megamanAscii += " ";
                    break;
                case "48":
                    megamanAscii += "©";
                    break;
                case "50":
                    megamanAscii += "0";
                    break;
                case "51":
                    megamanAscii += "1";
                    break;
                case "52":
                    megamanAscii += "2";
                    break;
                case "53":
                    megamanAscii += "3";
                    break;
                case "54":
                    megamanAscii += "4";
                    break;
                case "55":
                    megamanAscii += "5";
                    break;
                case "56":
                    megamanAscii += "6";
                    break;
                case "57":
                    megamanAscii += "7";
                    break;
                case "58":
                    megamanAscii += "8";
                    break;
                case "59":
                    megamanAscii += "9";
                    break;
                default:
                    megamanAscii += " ";
                    textFlag = 1;
                    break;
            }

            return megamanAscii;
        }

        // Title Screen
        private string decodeRomText2(string tempHexString)
        {
            string megamanAscii = "";
            textFlag = 0;

            switch (tempHexString)
            {
                case "81":
                    megamanAscii += "A";
                    break;
                case "82":
                    megamanAscii += "B";
                    break;
                case "83":
                    megamanAscii += "C";
                    break;
                case "84":
                    megamanAscii += "D";
                    break;
                case "85":
                    megamanAscii += "E";
                    break;
                case "86":
                    megamanAscii += "F";
                    break;
                case "87":
                    megamanAscii += "G";
                    break;
                case "88":
                    megamanAscii += "H";
                    break;
                case "89":
                    megamanAscii += "I";
                    break;
                case "8A":
                    megamanAscii += "J";
                    break;
                case "8B":
                    megamanAscii += "K";
                    break;
                case "8C":
                    megamanAscii += "L";
                    break;
                case "8D":
                    megamanAscii += "M";
                    break;
                case "8E":
                    megamanAscii += "N";
                    break;
                case "8F":
                    megamanAscii += "O";
                    break;
                case "90":
                    megamanAscii += "P";
                    break;
                case "91":
                    megamanAscii += "O";
                    break;
                case "92":
                    megamanAscii += "R";
                    break;
                case "93":
                    megamanAscii += "S";
                    break;
                case "94":
                    megamanAscii += "T";
                    break;
                case "95":
                    megamanAscii += "U";
                    break;
                case "96":
                    megamanAscii += "V";
                    break;
                case "97":
                    megamanAscii += "W";
                    break;
                case "98":
                    megamanAscii += "X";
                    break;
                case "99":
                    megamanAscii += "Y";
                    break;
                case "9A":
                    megamanAscii += "Z";
                    break;
                case "9B": // SPECIAL CASE (r.) Find a single letter to represent the "r.", we will repesent that with a hat ^
                    //megamanAscii += "r.";
                    megamanAscii += "^";
                    break;
                case "9C":
                    megamanAscii += ".";
                    break;
                case "9D":
                    megamanAscii += ",";
                    break;
                case "9E":
                    megamanAscii += "'";
                    break;
                case "9F":
                    megamanAscii += "!";
                    break;
                case "C8":
                    megamanAscii += "©";
                    break;
                    // Note: D0-D9 work on the title screen when written, AA AB AC AD must be references for 1987
                case "D0":
                    megamanAscii += "0";
                    break;
                case "D1":
                case "AA":
                    megamanAscii += "1";
                    break;
                case "D2":
                    megamanAscii += "2";
                    break;
                case "D3":
                    megamanAscii += "3";
                    break;
                case "D4":
                    megamanAscii += "4";
                    break;
                case "D5":
                    megamanAscii += "5";
                    break;
                case "D6":
                    megamanAscii += "6";
                    break;
                case "D7":
                case "AD":
                    megamanAscii += "7";
                    break;
                case "D8":
                case "AC":
                    megamanAscii += "8";
                    break;
                case "D9":
                case "AB":
                    megamanAscii += "9";
                    break;
                case "A0":
                    megamanAscii += " ";
                    break;
                default:
                    megamanAscii += " ";
                    textFlag = 1;
                    break;
            }

            return megamanAscii;
        }

        // End Credits
        private string decodeRomText3(string tempHexString)
        {
            string megamanAscii = "";
            textFlag = 0;

            switch (tempHexString)
            {
                case "04":
                    megamanAscii += " ";
                    break;
                case "5C":
                    megamanAscii += "1";
                    break;
                case "5F":
                    megamanAscii += "7";
                    break;
                case "5E":
                    megamanAscii += "8";
                    break;
                case "5D":
                    megamanAscii += "9";
                    break;
                case "61":
                    megamanAscii += "A";
                    break;
                case "62":
                    megamanAscii += "B";
                    break;
                case "63":
                    megamanAscii += "C";
                    break;
                case "64":
                    megamanAscii += "D";
                    break;
                case "65":
                    megamanAscii += "E";
                    break;
                case "66":
                    megamanAscii += "F";
                    break;
                case "67":
                    megamanAscii += "G";
                    break;
                case "68":
                    megamanAscii += "H";
                    break;
                case "69":
                    megamanAscii += "I";
                    break;
                case "6A":
                    megamanAscii += "J";
                    break;
                case "6B":
                    megamanAscii += "K";
                    break;
                case "6C":
                    megamanAscii += "L";
                    break;
                case "6D":
                    megamanAscii += "M";
                    break;
                case "6E":
                    megamanAscii += "N";
                    break;
                case "6F":
                    megamanAscii += "O";
                    break;
                case "70":
                    megamanAscii += "P";
                    break;
                case "71":
                    megamanAscii += "Q";
                    break;
                case "72":
                    megamanAscii += "R";
                    break;
                case "73":
                    megamanAscii += "S";
                    break;
                case "74":
                    megamanAscii += "T";
                    break;
                case "75":
                    megamanAscii += "U";
                    break;
                case "76":
                    megamanAscii += "V";
                    break;
                case "77":
                    megamanAscii += "W";
                    break;
                case "78":
                    megamanAscii += "X";
                    break;
                case "79":
                    megamanAscii += "Y";
                    break;
                case "7A":
                    megamanAscii += "Z";
                    break;
                case "7B": // SPECIAL CASE (r.) Find a single letter to represent the "r.", we will repesent that with a hat ^
                    //megamanAscii += "r.";
                    megamanAscii += "^";
                    break;
                case "7C":
                    megamanAscii += ".";
                    break;
                case "7D":
                    megamanAscii += ",";
                    break;
                case "7F":
                    megamanAscii += "!";
                    break;
                default:
                    megamanAscii += " ";
                    textFlag = 1;
                    break;
            }

            return megamanAscii;
        }

        private string encodeRomText1(string tempascii)
        {
            string megamanHex = "";
            tempascii = tempascii.ToUpper();

            switch (tempascii)
            {
                case "A":
                    megamanHex += "01";
                    break;
                case "B":
                    megamanHex += "02";
                    break;
                case "C":
                    megamanHex += "03";
                    break;
                case "D":
                    megamanHex += "04";
                    break;
                case "E":
                    megamanHex += "05";
                    break;
                case "F":
                    megamanHex += "06";
                    break;
                case "G":
                    megamanHex += "07";
                    break;
                case "H":
                    megamanHex += "08";
                    break;
                case "I":
                    megamanHex += "09";
                    break;
                case "J":
                    megamanHex += "0A";
                    break;
                case "K":
                    megamanHex += "0B";
                    break;
                case "L":
                    megamanHex += "0C";
                    break;
                case "M":
                    megamanHex += "0D";
                    break;
                case "N":
                    megamanHex += "0E";
                    break;
                case "O":
                    megamanHex += "0F";
                    break;
                case "P":
                    megamanHex += "10";
                    break;
                case "Q":
                    megamanHex += "11";
                    break;
                case "R":
                    megamanHex += "12";
                    break;
                case "S":
                    megamanHex += "13";
                    break;
                case "T":
                    megamanHex += "14";
                    break;
                case "U":
                    megamanHex += "15";
                    break;
                case "V":
                    megamanHex += "16";
                    break;
                case "W":
                    megamanHex += "17";
                    break;
                case "X":
                    megamanHex += "18";
                    break;
                case "Y":
                    megamanHex += "19";
                    break;
                case "Z":
                    megamanHex += "1A";
                    break;
                //case "r.":
                case "^": // SPECIAL CASE (r.) Find a single letter to represent the "r.", we will repesent that with a hat ^
                    megamanHex += "1B";
                    break;
                case ".":
                    megamanHex += "1C";
                    break;
                case ",":
                    megamanHex += "1D";
                    break;
                case "'":
                    megamanHex += "1E";
                    break;
                case "!":
                    megamanHex += "1F";
                    break;
                case " ":
                    megamanHex += "20";
                    break;
                case "©":
                    megamanHex += "48";
                    break;
                case "0":
                    megamanHex += "50";
                    break;
                case "1":
                    megamanHex += "51";
                    break;
                case "2":
                    megamanHex += "52";
                    break;
                case "3":
                    megamanHex += "53";
                    break;
                case "4":
                    megamanHex += "54";
                    break;
                case "5":
                    megamanHex += "55";
                    break;
                case "6":
                    megamanHex += "56";
                    break;
                case "7":
                    megamanHex += "57";
                    break;
                case "8":
                    megamanHex += "58";
                    break;
                case "9":
                    megamanHex += "59";
                    break;
                default: // space
                    megamanHex += "20";
                    break;
            }

            return megamanHex;
        }

        private string encodeRomText2(string tempascii)
        {
            string megamanHex = "";
            tempascii = tempascii.ToUpper();

            switch (tempascii)
            {
                case "A":
                    megamanHex += "81";
                    break;
                case "B":
                    megamanHex += "82";
                    break;
                case "C":
                    megamanHex += "83";
                    break;
                case "D":
                    megamanHex += "84";
                    break;
                case "E":
                    megamanHex += "85";
                    break;
                case "F":
                    megamanHex += "86";
                    break;
                case "G":
                    megamanHex += "87";
                    break;
                case "H":
                    megamanHex += "88";
                    break;
                case "I":
                    megamanHex += "89";
                    break;
                case "J":
                    megamanHex += "8A";
                    break;
                case "K":
                    megamanHex += "8B";
                    break;
                case "L":
                    megamanHex += "8C";
                    break;
                case "M":
                    megamanHex += "8D";
                    break;
                case "N":
                    megamanHex += "8E";
                    break;
                case "O":
                    megamanHex += "8F";
                    break;
                case "P":
                    megamanHex += "90";
                    break;
                case "Q":
                    megamanHex += "91";
                    break;
                case "R":
                    megamanHex += "92";
                    break;
                case "S":
                    megamanHex += "93";
                    break;
                case "T":
                    megamanHex += "94";
                    break;
                case "U":
                    megamanHex += "95";
                    break;
                case "V":
                    megamanHex += "96";
                    break;
                case "W":
                    megamanHex += "97";
                    break;
                case "X":
                    megamanHex += "98";
                    break;
                case "Y":
                    megamanHex += "99";
                    break;
                case "Z":
                    megamanHex += "9A";
                    break;
                //case "r.":
                case "^": // SPECIAL CASE (r.) Find a single letter to represent the "r.", we will repesent that with a hat ^
                    megamanHex += "9B";
                    break;
                case ".":
                    megamanHex += "9C";
                    break;
                case ",":
                    megamanHex += "9D";
                    break;
                case "'":
                    megamanHex += "9E";
                    break;
                case "!":
                    megamanHex += "9F";
                    break;
                case " ":
                    megamanHex += "A0";
                    break;
                case "©":
                    megamanHex += "C8";
                    break;
                case "0":
                    megamanHex += "D0";
                    break;
                case "1":
                    megamanHex += "D1";
                    break;
                case "2":
                    megamanHex += "D2";
                    break;
                case "3":
                    megamanHex += "D3";
                    break;
                case "4":
                    megamanHex += "D4";
                    break;
                case "5":
                    megamanHex += "D5";
                    break;
                case "6":
                    megamanHex += "D6";
                    break;
                case "7":
                    megamanHex += "D7";
                    break;
                case "8":
                    megamanHex += "D8";
                    break;
                case "9":
                    megamanHex += "D9";
                    break;
                default: // space
                    megamanHex += "A0";
                    break;
            }

            return megamanHex;
        }

        private string encodeRomText3(string tempascii) {
            string megamanHex = "";
            tempascii = tempascii.ToUpper();

            switch (tempascii) {
                case "A":
                    megamanHex += "61";
                    break;
                case "B":
                    megamanHex += "62";
                    break;
                case "C":
                    megamanHex += "63";
                    break;
                case "D":
                    megamanHex += "64";
                    break;
                case "E":
                    megamanHex += "65";
                    break;
                case "F":
                    megamanHex += "66";
                    break;
                case "G":
                    megamanHex += "67";
                    break;
                case "H":
                    megamanHex += "68";
                    break;
                case "I":
                    megamanHex += "69";
                    break;
                case "J":
                    megamanHex += "6A";
                    break;
                case "K":
                    megamanHex += "6B";
                    break;
                case "L":
                    megamanHex += "6C";
                    break;
                case "M":
                    megamanHex += "6D";
                    break;
                case "N":
                    megamanHex += "6E";
                    break;
                case "O":
                    megamanHex += "6F";
                    break;
                case "P":
                    megamanHex += "70";
                    break;
                case "Q":
                    megamanHex += "71";
                    break;
                case "R":
                    megamanHex += "72";
                    break;
                case "S":
                    megamanHex += "73";
                    break;
                case "T":
                    megamanHex += "74";
                    break;
                case "U":
                    megamanHex += "75";
                    break;
                case "V":
                    megamanHex += "76";
                    break;
                case "W":
                    megamanHex += "77";
                    break;
                case "X":
                    megamanHex += "78";
                    break;
                case "Y":
                    megamanHex += "79";
                    break;
                case "Z":
                    megamanHex += "7A";
                    break;
                //case "r.":
                case "^": // SPECIAL CASE (r.) Find a single letter to represent the "r.", we will repesent that with a hat ^
                    megamanHex += "7B";
                    break;
                case ".":
                    megamanHex += "7C";
                    break;
                case ",":
                    megamanHex += "7D";
                    break;
                case "'":
                    megamanHex += "7E";
                    break;
                case "!":
                    megamanHex += "7F";
                    break;
                case " ":
                    megamanHex += "04";
                    break;
                    // 1987 are the only numbers available in the ending
                case "1":
                    megamanHex += "5C";
                    break;
                case "7":
                    megamanHex += "5F";
                    break;
                case "8":
                    megamanHex += "5E";
                    break;
                case "9":
                    megamanHex += "5D";
                    break;
                default: // space
                    megamanHex += "04";
                    break;
            }

            return megamanHex;
        }
    }
}
