﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ClassLibraryOfMemes.DTO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ClassLibraryOfMemes
{
    public class VkAuth
    {
        public event Action OnAuthorized;
        public string RedirectPage => "https://oauth.vk.com/blank.html";

        private string Account { get; set; }

        private const string VkApiMethodTemplate = "https://api.vk.com/method/{0}";

        private string _token;
        private string _clientId = "6295092";
        private long _userId;

        private const string TokenFile = "auth.txt";

        public void CheckAuthorization()
        {
            try
            {
                _token = File.ReadAllText(TokenFile);
                if (!string.IsNullOrEmpty(_token))
                    OnAuthorized?.Invoke();
            }
            catch {}
        }

        public void ClearCookies()
        {
            File.Delete(TokenFile);
            Process.Start("cmd.exe", "/C RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 255"); //http://www.cyberforum.ru/csharp-net/thread401794.html
        }

        // Save the token to a file
        // This is a very simple way, in real applications tokens should not be stored in plain text!
        public void SaveToken(string newToken)
        {
            _token = newToken;
            File.WriteAllText(TokenFile, newToken);
        }

        // Regular expressions for extracting access_token and user_id from redirect
        Regex _authTokenRegex = new Regex(@"access_token=([\d\w]+)", RegexOptions.Compiled);
        Regex _userIdRegex = new Regex(@"user_id=([\d]+)", RegexOptions.Compiled);

        public void AuthorizationRedirect(Uri uri)
        {
            var m = _authTokenRegex.Match(uri.Fragment);
            if (m.Success)
            {
                SaveToken(m.Groups[1].Value);
            }

            m = _userIdRegex.Match(uri.Fragment);
            if (m.Success)
            {
                long.TryParse(m.Groups[1].Value, out _userId);
            }
            OnAuthorized?.Invoke();
        }

        public bool IsAuthorized
        {
            get
            {
                return !string.IsNullOrEmpty(_token);
            }
        }

        private string BuildUrl(string baseUrl, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var sb = new StringBuilder(baseUrl);
            if (parameters?.Count() > 0)
            {
                sb.Append('?');
                foreach (var p in parameters)
                {
                    sb.Append(p.Key);
                    sb.Append("=");
                    sb.Append(WebUtility.UrlEncode(p.Value));  // This is the important part - percent-encoding
                    sb.Append('&');
                }
                sb.Remove(sb.Length - 1, 1);    // Remove the last '&'
            }
            return sb.ToString();
        }

        public string GetAuthUrl()
        {
            return BuildUrl($"https://oauth.vk.com/authorize",
                new KeyValuePair<string, string>[] {
                    new KeyValuePair<string, string>("response_type", "token"),
                    new KeyValuePair<string, string>("client_id", _clientId),
                    new KeyValuePair<string, string>("redirect_url", RedirectPage),
                    new KeyValuePair<string, string>("scope", Account)
                });
        }

        public async Task<string> GetUserName()
        {
            if (IsAuthorized)
            {
                using (var client = new HttpClient())
                {
                    var resultStr = await client.GetStringAsync(
                        BuildUrl(string.Format(VkApiMethodTemplate, "account.getProfileInfo"),
                        new KeyValuePair<string, string>[] {
                        new KeyValuePair<string, string>("access_token", _token),
                        new KeyValuePair<string, string>("user_id", _userId.ToString())
                        }));
                    var userNameResponse = JsonConvert.DeserializeObject<UserNameResponse>(resultStr);
                    if (userNameResponse.Response != null)
                    {
                        return userNameResponse.Response.first_name + " " + userNameResponse.Response.last_name;
                    }
                    else
                    {
                        ClearCookies();
                        return null;
                    }
                }
            }
            return "";
        }
    }
}
