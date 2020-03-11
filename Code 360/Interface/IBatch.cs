﻿using Code_360.Models.Batch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.Interface
{
    public interface IBatch
    {
        Batch GetBatch(Guid Id);
        Batch AddBatch(Batch _batch);
        Batch UpdateBatch(Batch _batchUpdate);
        Batch RemoveBatch(Guid Id);
        IEnumerable<Batch> GetBatches();
    }
}
