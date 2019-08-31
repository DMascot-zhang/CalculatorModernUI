using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDLL;

namespace ControllerDLL
{
    public class PermissionesDomain
    {
        private bool PermissionText;
        private bool PermissionNull;
        private bool PermissionDot;

        public PermissionesDomain()
        {
            PermissionText = true;
            PermissionNull = true;
            PermissionDot = true;
        }

        //SET PERMISSIONES

        public void setPermissionText(bool pt)
        {
            this.PermissionText = pt;
        }

        public void setPermissionNull(bool nul)
        {
            this.PermissionNull = nul;
        }

        public void setPermissionDot(bool dot)
        {
            this.PermissionDot = dot;
        }


        //GET PERMISSIONES

        public bool isPermissionText()
        {
            return PermissionText;
        }

        public bool isPermissionNull()
        {
            return PermissionNull;
        }

        public bool isPermissionDot()
        {
            return PermissionDot;
        }

    }

    public class Controller
    {
      PermissionesDomain Permissiones = new PermissionesDomain();
      Model model = new Model();

    /**
    * Проверяльщик изменения текста
    **/
      public bool changeText(string textBox1)
      {
          if (textBox1.Length >= 40)
          {
              Permissiones.setPermissionText(false);

          }
          else
          {
              Permissiones.setPermissionText(true);
          }

          return Permissiones.isPermissionText();
      }

      /**
      * Null
      **/
        public string clickOnNull(string nameBt, string textBox1)
        {
            if (Permissiones.isPermissionText())
            {
                if ((textBox1 == "" || textBox1 == "0") && Permissiones.isPermissionNull())
                {
                    textBox1 = nameBt;

                }
                else if (textBox1 != "" && Permissiones.isPermissionNull())
                {
                    switch (textBox1[textBox1.Length - 1])
                    {
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                        case ' ':
                            textBox1 += nameBt;
                            Permissiones.setPermissionNull(false);
                            break;
                        default:
                            textBox1 += nameBt;

                            break;
                    }
                    
                }

            }

            return textBox1;
        }

        /**
        * Num
        **/
        public string clicOnNum(string nameBt, string textBox1)
        {
            
            if (Permissiones.isPermissionText())
            {

                //Положительное число
                if (textBox1 == "0" || textBox1 == "")
                {
                    textBox1 = nameBt;
                }
                else
                {

                    switch (textBox1[textBox1.Length - 1])
                    {
                        case '0':

                            switch (textBox1[textBox1.Length - 2])
                            {
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case ' ':
                                    textBox1 = textBox1.Remove(textBox1.Length - 1);
                                    textBox1 += nameBt;

                                    break;
                                default:
                                    textBox1 += nameBt;

                                    break;
                            }
                            break;

                        default:
                            textBox1 += nameBt;
                            break;   
                    }


                }
                Permissiones.setPermissionNull(true);
            }       

            return textBox1;
        }


        /**
        *  Char
        **/
        public string clicOnChar(string nameChar, string textBox1)
        {
            
            if (Permissiones.isPermissionText())
            {

                if (textBox1 == "")
                {
                    textBox1 = "0 " + nameChar + " ";

                }
                else
                {

                    String[] words = textBox1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    double d;

                    textBox1 = "";

                    for (int i = 0; i < words.Length; i++)
                    {
                        if (Double.TryParse(words[i], out d))
                        {
                            textBox1 += Convert.ToString(d);

                        }
                        else
                        {
                            if (words[i] == "(" || words[i] == ")")
                            {
                                textBox1 +=  words[i] + " ";                            
                            }
                            else
                            {
                                textBox1 += " " + words[i] + " ";
                            }
                        }
                    }

                    switch (textBox1[textBox1.Length - 1])
                    {

                        case ',':
                            textBox1 = textBox1.Remove(textBox1.Length - 1);
                            textBox1 += " " + nameChar + " ";
                            break;
                            //смена знака
                         case ' ':
                         case '(':
                         case ')':
                            switch (textBox1[textBox1.Length - 2])
                            {
                                case '(':
                                case ')':
                                    textBox1 += nameChar + " ";
                                    break;
                                //убирание пробелов при смене знака
                                default:
                                    textBox1 = textBox1.Remove(textBox1.Length - 2);
                                    textBox1 += nameChar + " ";
                                    break;
                            }
                            break;
                        default:
                            textBox1 += " " + nameChar + " ";
                            break;
                    }

                }

                Permissiones.setPermissionNull(true);
                Permissiones.setPermissionDot(true);
            }              

            return textBox1;
        }


        /**
        *  Dot
        **/
        public string clickOnDot(string nameChar, string textBox1)
        {
            if (Permissiones.isPermissionText())
            {
                if (Permissiones.isPermissionDot())
                {

                    if (textBox1 == "")
                    {
                        textBox1 = "0" + nameChar;
                    }
                    else
                    {
                        switch (textBox1[textBox1.Length - 1])
                        {
                            case '+':
                            case '-':
                            case '*':
                            case '/':
                            case ' ':
                                textBox1 += "0" + nameChar;
                                break;
                            default:
                                textBox1 += nameChar;
                                break;
                        }
                    }


                }
                Permissiones.setPermissionDot(false);
                Permissiones.setPermissionNull(true);
            }

            return textBox1;
        }

        /**
        *  Скобки
        **/

        public string clickOnLeftScobka(string nameChar, string textBox1)
        {
            if (Permissiones.isPermissionText())
            {
           
                    if (textBox1 == "")
                    {
                        textBox1 = nameChar + " ";


                    }
                    else
                    {
                        switch (textBox1[textBox1.Length - 1])
                        {
                            case '+':
                            case '-':
                            case '*':
                            case '/':
                            case ' ':
                                textBox1 += nameChar + " ";

                                break;
                            default:
                               
                                break;
                        }
                    }


                }

            return textBox1;
        }



        public string clickOnRightScobka(string nameChar, string textBox1)
        {
            if (Permissiones.isPermissionText())  {


                    if (textBox1 == "( ")
                    {
                        textBox1 += "0 " + nameChar;
                    }
                    else
                    {
                        switch (textBox1[textBox1.Length - 1])
                        {
                            case '+':
                            case '-':
                            case '*':
                            case '/':
                            case ' ':
                                textBox1 += " " + nameChar + " ";

                                break;
                            default:
                                  textBox1 += " " + nameChar + " ";

                                break;
                        }
                    }


                }

            return textBox1;
        }

       /**
       *  Очищение знаков
       **/

        public string cleanOneChar(string textBox1)
        {
            if (textBox1 != "")
            {
                if (textBox1[textBox1.Length - 1] == ' ')
                {
                    textBox1 = textBox1.Remove(textBox1.Length - 3);
                }
                else
                {
                    textBox1 = textBox1.Remove(textBox1.Length - 1);
                }
            }

            return textBox1;
        }

        public string restartCalc(string textBox1)
        {
            textBox1 = "";
            Permissiones = new PermissionesDomain();

            return textBox1;
        }

        /**
       *  Сектор ответа 
       **/

        public string answerCalc(string textBox1)
        {

              try{
               
                    switch (textBox1[textBox1.Length - 2])
                    {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        textBox1 = textBox1.Remove(textBox1.Length - 3);
                        break;
                }
     
                } catch {

                }

           return model.Calculate(textBox1);

        }

    }
}
