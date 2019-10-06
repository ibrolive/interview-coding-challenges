using Interview.Algorithm.DynamicProgramming;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question355
    {

    }

    public class Twitter
    {
        Dictionary<int, List<int>> followers = null;
        List<Tweet> tweets = null;

        class Tweet
        {
            public int UID;
            public int tweetId;
            public DateTime date;

            public Tweet(int uid, int tweetId)
            {
                this.UID = uid;
                this.tweetId = tweetId;
                date = DateTime.Now;
            }

        }

        public Twitter()
        {
            tweets = new List<Tweet>();
            followers = new Dictionary<int, List<int>>();
        }

        public void PostTweet(int userId, int tweetId)
        {
            tweets.Add(new Tweet(userId, tweetId));
        }

        public IList<int> GetNewsFeed(int userId)
        {
            if (followers.ContainsKey(userId))
                return tweets.Where(x => x.UID == userId || followers[userId].Contains(x.UID))
                              .OrderByDescending(t => t.date)
                              .Take(10)
                              .Select(tweet => tweet.tweetId)
                              .ToList();
            else
                return tweets.Where(x => x.UID == userId)
                              .OrderByDescending(t => t.date)
                              .Take(10)
                              .Select(tweet => tweet.tweetId)
                              .ToList();
        }

        public void Follow(int followerId, int followeeId)
        {
            if (!followers.ContainsKey(followerId))
                followers.Add(followerId, new List<int>());

            followers[followerId].Add(followeeId);
        }

        public void Unfollow(int followerId, int followeeId)
        {
            if (followers.ContainsKey(followerId))
                followers[followerId].Remove(followeeId);
        }
    }
}
