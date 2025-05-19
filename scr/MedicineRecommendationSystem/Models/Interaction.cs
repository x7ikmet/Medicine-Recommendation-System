using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace MedicineRecommendationSystem.Models;



public class DrugEntry
{
    public string name { get; set; }
    public string internalID { get; set; }
}

public class DrugResponse
{
    public List<DrugEntry> data { get; set; }
}


public class InteractionData
{
    public string color { get; set; }
    public string idx__level { get; set; }
    public string idx__interaction_description { get; set; }
}

public class InteractionResponse
{
    public string state { get; set; }
    public List<InteractionData> data { get; set; }
}



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
                    //MessageBox.Show(csrfmiddlewaretoken);
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

                    // Deserialize JSON
                    var drugResponse = JsonConvert.DeserializeObject<DrugResponse>(result);

                    // Find exact match (case-insensitive)
                    var match = drugResponse.data
                        .FirstOrDefault(d => string.Equals(d.name, Drug, StringComparison.OrdinalIgnoreCase));

                    if (match != null)
                        return match.internalID;
                    else
                        //MessageBox.Show("No exact match found.");
                        return null;
                }
                else
                {
                    //MessageBox.Show("Error: " + response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message);
                return null;
            }

        }

        return "";
    }



    public (string Color, string Level, string Description)? InteractCheck(string Drug1, string Drug2)
    {
        string drugA = Search(Drug1);
        string drugB = Search(Drug2);

        if (string.IsNullOrEmpty(drugA) || string.IsNullOrEmpty(drugB))
        {
            //MessageBox.Show("One or both drugs not found.");
            return null;
        }

        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };

        using (HttpClient client = new HttpClient(handler))
        {
            client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
            client.DefaultRequestHeaders.Add("Accept", "application/json, text/javascript, */*; q=0.01");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            client.DefaultRequestHeaders.Add("Referer", "https://ddinter.scbdd.com/inter-checker/");
            client.DefaultRequestHeaders.Add("Origin", "https://ddinter.scbdd.com");

            var content = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("csrfmiddlewaretoken", csrfmiddlewaretoken),
            new KeyValuePair<string, string>("choices", drugA),
            new KeyValuePair<string, string>("choices", drugB)
        });

            try
            {
                HttpResponseMessage response = client.PostAsync("https://ddinter.scbdd.com/ddinter/checker/", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var interResponse = JsonConvert.DeserializeObject<InteractionResponse>(result);

                    if (interResponse.state == "success" && interResponse.data.Count > 0)
                    {
                        var interaction = interResponse.data[0];
                        MessageBox.Show("Interaction found: " + interaction.idx__interaction_description);
                        return (interaction.color, interaction.idx__level, interaction.idx__interaction_description);
                    }
                    else
                    {
                        // No interaction found
                        return null;
                    }
                }
                else
                {
                    //MessageBox.Show("API Error: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message);
            }
        }

        return null;
    }


}
