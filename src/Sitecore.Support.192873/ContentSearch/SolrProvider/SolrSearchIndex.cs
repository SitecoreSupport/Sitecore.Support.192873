using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Maintenance;
using Sitecore.ContentSearch.SolrProvider;
using SolrNet;

namespace Sitecore.Support.ContentSearch.SolrProvider
{
  public class SolrSearchIndex : Sitecore.ContentSearch.SolrProvider.SolrSearchIndex
  {
    private SolrIndexSchema schema;

    public override ISearchIndexSchema Schema => this.Schema;

    public SolrSearchIndex(string name, string core, IIndexPropertyStore propertyStore, string group) : base(name, core, propertyStore, group)
    {
      var solrOperations = typeof(Sitecore.ContentSearch.SolrProvider.SolrSearchIndex)
        .GetProperty("SolrOperations", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this)
        as ISolrOperations<Dictionary<string, object>>;

      this.schema = new SolrIndexSchema(solrOperations.GetSchema());
    }
  }
}