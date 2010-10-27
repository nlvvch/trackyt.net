﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trackyourtasks.Core.DAL.DataModel;

namespace Trackyourtasks.Core.DAL.Extensions
{
    public static class BlogPostsExtensions
    {
        public static BlogPost WithId(this IQueryable<BlogPost> posts, int id)
        {
            return posts.Where(p => p.Id == id).SingleOrDefault();
        }

        public static IQueryable<BlogPost> Page(this IQueryable<BlogPost> posts, int page, int pageSize)
        {
            return posts.Skip(page * pageSize).Take(pageSize);
        }
    }
}