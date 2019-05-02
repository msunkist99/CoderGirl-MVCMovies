﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    // TODO: Implement this interface
    public interface IMovieRatingRepository
    {        
        /// <summary>
        /// Given a movieName and rating, saves the rating and returns a unique id > 0.
        /// If the movie name and/or rating are null or empty, nothing should be saved and it should return 0
        /// </summary>
        /// <param name="movieName"></param>
        /// <param name="rating"></param>
        /// <returns></returns>
        int SaveRating(string movieName, int rating);

        /// <summary>
        /// Given an id, will return the associated rating 
        /// If the id does not exist, returns 0
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        int GetRatingById(int id);

        /// <summary>
        /// Given an id, will return the associated movie name.
        /// If the id does not exist, return null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetMovieNameById(int id);

        /// <summary>
        /// Given a movie name, returns the average rating of of the movie.
        /// If there are no ratings for the movie, returns an empty list.
        /// </summary>
        /// <param name="movieName"></param>
        /// <returns></returns>
        decimal GetAverageRatingByMovieName(string movieName);

        /// <summary>
        /// Returns a list of all the ids of saved movie ratings
        /// </summary>
        /// <returns></returns>
        List<int> GetIds();
    }
}
