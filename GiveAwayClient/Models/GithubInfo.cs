
using GiveAwayClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace LastAssignment
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    public class GithubInfo
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }

        public string UserAgent {get; set;}

        public GithubInfo()
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.GET;
            UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
        }

        public string MakeRequest(string username, string password)
        {
            try
            {
                string strResponseValue = string.Empty;

                //List<Repos> obj = new List<Repos>();

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

                request.Headers[HttpRequestHeader.Authorization] = "Basic " +
                             Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));


                request.UserAgent = UserAgent;


                //var httpRequestProperty = new HttpRequestMessageProperty();
                //httpRequestProperty.Headers[System.Net.HttpRequestHeader.Authorization] = "Basic " +
                //             Convert.ToBase64String(Encoding.ASCII.GetBytes(client.ClientCredentials.UserName.UserName + ":" +
                //             client.ClientCredentials.UserName.Password));
                //OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;

                //client.DoSomething();










                request.Method = httpMethod.ToString();


                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new ApplicationException("error code" + response.StatusCode);
                    }

                    using (Stream responseStream = response.GetResponseStream())


                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                strResponseValue = reader.ReadToEnd();


                            }


                        }
                    }


                }

                return strResponseValue;

            }
            catch (Exception)
            {

                throw;
            }
            
           
        }

        public int PostRequest(Rootobject rootobject)
        {
            string result = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

                var jsonw = new JavaScriptSerializer().Serialize(rootobject);

                request.Method = httpMethod.ToString();

                request.ContentType = "application/json; charset=utf-8";
                request.ContentLength = jsonw.Length;


                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = jsonw;
                    Debug.Write(json);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    if (request.HaveResponse && response != null)
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                             result = reader.ReadToEnd();

                            
                        }
                    }

                    
                }

                int temp= Convert.ToInt32(result);

                return temp;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }

}
