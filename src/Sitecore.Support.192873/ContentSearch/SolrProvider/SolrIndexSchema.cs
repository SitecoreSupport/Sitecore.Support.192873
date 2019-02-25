using SolrNet.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support.ContentSearch.SolrProvider
{
  public class SolrIndexSchema : Sitecore.ContentSearch.SolrProvider.SolrIndexSchema
  {
    private readonly SolrSchema schema;

    private readonly List<string> allFields;

    private readonly List<string> allCultures;

    public override ICollection<string> AllFieldNames => allFields;

    public override ICollection<string> AllCultures => allCultures;

    public new SolrSchema SolrSchema => schema;

    public SolrIndexSchema(SolrSchema schema) : base(schema)
    {
      this.schema = schema;

      allFields = (from x in this.schema.SolrFields
                   select x.Name).ToList();

      allCultures = (from x in this.schema.SolrDynamicFields
                     where x.Name.StartsWith("*_t_")
                     select x.Name).ToList();
    }
  }
}