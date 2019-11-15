using HC.Core.Types;

namespace HC.Core.DataTypes
{
  public class OnOffData : AbstractData<OnOffState?>
  {
    public static OnOffData ON => new OnOffData(OnOffState.ON);
    public static OnOffData OFF => new OnOffData(OnOffState.OFF);

    public OnOffData() : base() { }

    protected OnOffData(OnOffState value) : base(value) { }
  }
}