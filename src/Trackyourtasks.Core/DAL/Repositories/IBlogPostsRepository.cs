﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trackyourtasks.Core.DAL.DataModel;

namespace Trackyourtasks.Core.DAL.Repositories
{
    /// <summary>
    /// Repository of Blog posts
    /// </summary>
    public interface IBlogPostsRepository
    {
        /// <summary>
        /// Gets all blog posts from repository
        /// </summary>
        IQueryable<BlogPost> BlogPosts { get; }

        /// <summary>
        /// Creates new record and initialize Id for new objects and update exiting objects
        /// </summary>
        /// <param name="blogPost">Blog post object</param>
        void SaveBlogPost(BlogPost blogPost);

        /// <summary>
        /// Deletes blog post
        /// </summary>
        /// <param name="blogPost"></param>
        void DeleteBlogPost(BlogPost blogPost);
    }
}
