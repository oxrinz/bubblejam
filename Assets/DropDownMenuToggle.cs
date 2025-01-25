using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownMenuToggle : MonoBehaviour
{
    public GameObject dropdownMenu; // The dropdown menu that will show/hide
    public GameObject moreButton; // The More button to control the visibility
    
    private bool isDropdownVisible = false; // Track the dropdown state

    public void ToggleDropdown()
    {
        // Toggle the visibility of the dropdown menu
        isDropdownVisible = !isDropdownVisible;
        dropdownMenu.SetActive(isDropdownVisible);
        
    }
}
