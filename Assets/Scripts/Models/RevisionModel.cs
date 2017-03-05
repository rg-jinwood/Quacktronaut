using System;
using System.Collections.Generic;

namespace Assets.Scripts.Models
{
    public class Translation
    {
        public string created_at { get; set; }
        public int id { get; set; }
        public int seq_id { get; set; }
        public string text { get; set; }
        public int variant_id { get; set; }
    }

    public class Variant
    {
        public int bit_id { get; set; }
        public string created_at { get; set; }
        public int id { get; set; }
        public List<string> primary_tags { get; set; }
        public object secondary_tags { get; set; }
        public int seq_id { get; set; }
        public string text { get; set; }
    }

    public class Datum
    {
        public int absolute_correct_run_length { get; set; }
        public int bit_id { get; set; }
        public string due_for_revision { get; set; }
        public int library_id { get; set; }
        public int spaced_correct_run_length { get; set; }
        public Translation translation { get; set; }
        public Variant variant { get; set; }
        public List<string> wrong_answers { get; set; }
    }

    public class RevisionModel
    {
        public List<Datum> data { get; set; }
    }

    //public class Data
    //{
    //    public List<Revision> Revisions { get; set; }
    //}

    //public class Revision
    //{
    //    public string absolute_correct_run_length { get; set; }
    //    public int bit_id { get; set; }
    //    public DateTime due_for_revision { get; set; }
    //    public int library_id { get; set; }
    //    public string spaced_correct_run_length { get; set; }
    //    public Translation translation { get; set; }
    //    public Variant variant { get; set; }
    //    public int variant_id { get; set; }
    //    public List<string> wrong_answers { get; set; }
    //}

    //public class Translation
    //{
    //    public DateTime created_at { get; set; }
    //    public int id { get; set; }
    //    public int seq_id { get; set; }
    //    public string text { get; set; }
    //    public int variant_id { get; set; }
    //}
    //public class Variant
    //{
    //    public int bit_id { get; set; }
    //    public DateTime created_at { get; set; }
    //    public int id { get; set; }
    //    public int seq_id { get; set; }
    //    public string text { get; set; }
    //    public List<string> primary_tags { get; set; }
    //    public List<string> secondary_tags { get; set; }
    //}
}
