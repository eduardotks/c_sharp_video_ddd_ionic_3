﻿using System;

namespace Project.Domain.Arguments.Video
{
    public class AdicionarVideoResponse
    {
        public AdicionarVideoResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
