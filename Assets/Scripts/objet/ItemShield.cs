using UnityEngine;

public class ItemShield : Item
{
    public override void utiliser()
    {
        base.utiliser();
        Personnage.Instance.Shield();   
    }
}
