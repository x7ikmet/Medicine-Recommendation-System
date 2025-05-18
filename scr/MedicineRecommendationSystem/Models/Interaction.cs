using System;
using System.Net;
using System.Net.Http;

namespace MedicineRecommendationSystem.Models;

public class Interaction
{

    string csrfmiddlewaretoken;
    public Interaction()
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };
        using (HttpClient client = new HttpClient(handler))
        {
            string url = "https://ddinter.scbdd.com/inter-checker/";
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    string marker = "csrfmiddlewaretoken: '";
                    int start = result.IndexOf(marker) + marker.Length;
                    int end = result.IndexOf("'", start);

                    csrfmiddlewaretoken = result.Substring(start, end - start);
                    MessageBox.Show(csrfmiddlewaretoken);
                }
                else
                {
                    MessageBox.Show("Error: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }

    public string Search(string Drug)
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };
        using (HttpClient client = new HttpClient(handler))
        {
            string url = $"https://ddinter.scbdd.com/check-datasource/{Drug}/?csrfmiddlewaretoken={csrfmiddlewaretoken}";
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    MessageBox.Show(result);
                }
                else
                {
                    MessageBox.Show("Error: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        return "";
    }



    public void Interact(string Drug1, string Drug2)
    {
        string drugA = Search(Drug1);
        string drugB = Search(Drug2);

    }

}
