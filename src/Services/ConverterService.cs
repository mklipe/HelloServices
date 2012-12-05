//
// ConverterService.cs
// This WebService accepts an arabic number and convert it in roman numbers
//
// Authors:
//       Mauricio Klipe <mklipe@yahoo.com.br>
//       Alex Wargenhak <alex_wargenhak@yahoo.com.br>
//       Johnny C. Siebeniehcler <johnny_jacare@gmail.com>
//
// Copyright (c) 2012 


using System;
using Funq;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;

namespace GestUAB.Services
{
    public class ConverterService
    {
        /// <summary>
        /// Define your ServiceStack web service request (i.e. the Request DTO).
        /// </summary>
        [Route("/convert")]
        [Route("/convert/{Value}")]
        public class Hello
        {
            public string Value { get; set; }
        }

        /// <summary>
        /// Define your ServiceStack web service response (i.e. Response DTO).
        /// </summary>
        public class HelloResponse
        {
            public string Result { get; set; }
        }

        /// <summary>
        /// Create your ServiceStack web service implementation.
        /// </summary>
        public class HelloService : IService<Hello>
        {
            public object Execute(Hello request)
            {
                //Looks strange when the name is null so we replace with a generic name.
                var x = request.Value ?? "Hey";

                String convertedValue = "";
                
                x = x.PadLeft(6, '0');
                int value = 0;
                try
                {
                    value = Convert.ToInt32(x);
                    if (value > 999999)
                    {
                        convertedValue = "Wrong Input";
                    }
                    else if (value == 0)
                        convertedValue = "Nulla";
                    else
                    {
                        switch (x[0])
                        {
                        case '1':
                            convertedValue += "C&#773;";
                            break;
                        case '2':
                            convertedValue += "C&#773;C&#773;";
                            break;
                        case '3':
                            convertedValue += "C&#773;C&#773;C&#773;";
                            break;
                        case '4':
                            convertedValue += "C&#773;D&#773;";
                            break;
                        case '5':
                            convertedValue += "D&#773;";
                            break;
                        case '6':
                            convertedValue += "D&#773;C&#773;";
                            break;
                        case '7':
                            convertedValue += "D&#773;C&#773;C&#773;";
                            break;
                        case '8':
                            convertedValue += "D&#773;C&#773;C&#773;C&#773;";
                            break;
                        case '9':
                            convertedValue += "C&#773;M&#773;";
                            break;
                            
                        }
                        
                        switch (x[1])
                        {
                        case '1':
                            convertedValue += "X&#773;";
                            break;
                        case '2':
                            convertedValue += "X&#773;X&#773;";
                            break;
                        case '3':
                            convertedValue += "X&#773;X&#773;X&#773;";
                            break;
                        case '4':
                            convertedValue += "X&#773;L&#773;";
                            break;
                        case '5':
                            convertedValue += "L&#773;";
                            break;
                        case '6':
                            convertedValue += "L&#773;X&#773;";
                            break;
                        case '7':
                            convertedValue += "L&#773;X&#773;X&#773;";
                            break;
                        case '8':
                            convertedValue += "L&#773;X&#773;X&#773;X&#773;";
                            break;
                        case '9':
                            convertedValue += "X&#773;C&#773;";
                            break;
                            
                        }
                        
                        switch (x[2])
                        {
                            case '1':
                                convertedValue += "M";
                                break;
                            case '2':
                                convertedValue += "MM";
                                break;
                            case '3':
                                convertedValue += "MMM";
                                break;
                            case '4':
                                convertedValue += "MV&#773;";
                                break;
                            case '5':
                                convertedValue += "V&#773;";
                                break;
                            case '6':
                                convertedValue += "V&#773;M";
                                break;
                            case '7':
                                convertedValue += "V&#773;MM";
                                break;
                            case '8':
                                convertedValue += "V&#773;MMM";
                                break;
                            case '9':
                                convertedValue += "MX&#773;";
                                break;
                           
                        }

                        switch (x[3])
                        {
                            case '1':
                                convertedValue += "C";
                                break;
                            case '2':
                                convertedValue += "CC";
                                break;
                            case '3':
                                convertedValue += "CCC";
                                break;
                            case '4':
                                convertedValue += "CD";
                                break;
                            case '5':
                                convertedValue += "D";
                                break;
                            case '6':
                                convertedValue += "DC";
                                break;
                            case '7':
                                convertedValue += "DCC";
                                break;
                            case '8':
                                convertedValue += "DCCC";
                                break;
                            case '9':
                                convertedValue += "CM";
                                break;
                        }

                        switch (x[4])
                        {
                            case '1':
                                convertedValue += "X";
                                break;
                            case '2':
                                convertedValue += "XX";
                                break;
                            case '3':
                                convertedValue += "XXX";
                                break;
                            case '4':
                                convertedValue += "XL";
                                break;
                            case '5':
                                convertedValue += "L";
                                break;
                            case '6':
                                convertedValue += "LX";
                                break;
                            case '7':
                                convertedValue += "LXX";
                                break;
                            case '8':
                                convertedValue += "LXXX";
                                break;
                            case '9':
                                convertedValue += "XC";
                                break;
                        }

                        switch (x[5])
                        {
                            case '1':
                                convertedValue += "I";
                                break;
                            case '2':
                                convertedValue += "II";
                                break;
                            case '3':
                                convertedValue += "III";
                                break;
                            case '4':
                                convertedValue += "IV";
                                break;
                            case '5':
                                convertedValue += "V";
                                break;
                            case '6':
                                convertedValue += "VI";
                                break;
                            case '7':
                                convertedValue += "VII";
                                break;
                            case '8':
                                convertedValue += "VIII";
                                break;
                            case '9':
                                convertedValue += "IX";
                                break;
                        }
                    }
                }
                catch {
                    convertedValue = "Wrong Input";
                }
               
                return new HelloResponse { Result = convertedValue };
            }
        }

    }
}