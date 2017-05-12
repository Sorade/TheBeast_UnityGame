public class LostItemReaction : DelayedReaction
{
    public string itemID;               // Item to be removed from the Inventory.


    private Inventory inventory;    // Reference to the Inventory component.


    protected override void SpecificInit()
    {
        inventory = FindObjectOfType<Inventory> ();
    }


    protected override void ImmediateReaction()
    {
        inventory.RemoveItem (itemID);
    }
}
