using Backfy.Common.Infra.Services.Interfaces;
using Backfy.Common.Infra.Services.Models;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Backfy.Common.Infra.Services
{
    /// <summary>
    /// The sportify service integration
    /// </summary>
    public class SpotifyService : ISpotifyService
    {
        private readonly string uriApiSpotify = "https://api.spotify.com/v1/";
        private readonly string uriApiSpotifyToken = "https://accounts.spotify.com/api/token";
        private readonly string clientId;
        private readonly string clientSecret;

        public SpotifyService(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
        }

        /// <inheritdoc />
        public async Task<SpotifyAlbum> GetAlbumAsync(string id)
        {
            IDictionary<string, object> result = await AlbumAsync(id);
            
            return new SpotifyAlbum { Id = result["id"].ToString(), Name = result["name"].ToString(), ReleaseDate = result["release_date"].ToString(), TotalTracks = int.Parse(result["total_tracks"].ToString()) };
        }

        /// <inheritdoc />
        public async Task<IEnumerable<SpotifyAlbum>> GetAlbumsAsync(string query, int limit, int offset)
        {
            var result = await SearchAsync(query, "album", limit, offset);
            IEnumerable<dynamic> albums = result.albums.items;

            return albums.Select(x => new SpotifyAlbum { Id = x.id, Name = x.name, ReleaseDate = x.release_date, TotalTracks = x.total_tracks }).ToList();
        }

        /// <summary>
        /// Get token to authenticate in spotify api 
        /// </summary>
        /// <returns>The token requested</returns>
        private async Task<dynamic> GetToken()
        {
            string credentials = String.Format("{0}:{1}", clientId, clientSecret);
            
            using (var client = new HttpClient())
            {
                //Define Headers
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));

                //Prepare Request Body
                List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials")
                };

                FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);
                
                var request = await client.PostAsync(uriApiSpotifyToken, requestBody);
                var response = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<dynamic>(response);
            }
        }

        /// <summary>
        /// Implements a get albums from spotify api
        /// </summary>
        /// <param name="id">The identifier of album</param>
        /// <returns>Task with dynamic object requested</returns>
        private async Task<dynamic> AlbumAsync(string id)
        {
            try
            {
                var token = await GetToken();

                return await uriApiSpotify
                    .AppendPathSegment($"albums/{id}")
                    .WithOAuthBearerToken((string)token.access_token)
                    .GetJsonAsync();
            }
            catch (FlurlHttpException ex)
            {
                var exception = await ex.GetResponseStringAsync();
                throw new Exception(exception);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Implements a get search from spotify api
        /// </summary>
        /// <param name="query">The query request</param>
        /// <param name="type">The type request</param>
        /// <param name="limit">The limit request</param>
        /// <param name="offset">The offset request</param>
        /// <returns>Task with dynamic object requested</returns>
        private async Task<dynamic> SearchAsync(string query, string type, int limit, int offset)
        {
            try
            {
                var token = await GetToken();

                return await uriApiSpotify
                    .AppendPathSegment("search")
                    .SetQueryParams($"q={query}&type={type}&market=from_token&limit={limit}&offset={1}")
                    .WithOAuthBearerToken((string)token.access_token)
                    .GetJsonAsync<dynamic>();
            }
            catch (FlurlHttpException ex)
            {
                var exception = await ex.GetResponseJsonAsync();
                throw new Exception(exception.error.message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
