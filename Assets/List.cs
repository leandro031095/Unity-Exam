using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using UnityEngine;

public class List : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var request = (HttpWebRequest)WebRequest.Create("https://randomuser.me/api/?results=50&callback=randomuserdata.");

            var postData = "jump=1";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Debug.Log(responseString);
        }
    }
}
