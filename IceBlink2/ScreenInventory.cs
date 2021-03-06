﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IceBlink2
{
    public class ScreenInventory 
    {
	    public Module mod;
	    public GameView gv;
	    private int inventoryPageIndex = 0;
	    private int inventorySlotIndex = 0;
	    private int slotsPerPage = 20;
	    private List<IbbButton> btnInventorySlot = new List<IbbButton>();
	    private IbbButton btnInventoryLeft = null;
	    private IbbButton btnInventoryRight = null;
	    private IbbButton btnPageIndex = null;
	    private IbbButton btnHelp = null;
	    private IbbButton btnInfo = null;
	    private IbbButton btnReturn = null;
	    private bool dialogOpen = false;
        private IbbHtmlTextBox description;
	
	    public ScreenInventory(Module m, GameView g)
	    {
		    mod = m;
		    gv = g;
		    //setControlsStart();
	    }
	
	    public void setControlsStart()
	    {			
    	    int pW = (int)((float)gv.screenWidth / 100.0f);
		    int pH = (int)((float)gv.screenHeight / 100.0f);
		    int padW = gv.squareSize/6;

            description = new IbbHtmlTextBox(gv, 320, 100, 500, 300);
            description.showBoxBorder = false;

		    if (btnInventoryLeft == null)
		    {
			    btnInventoryLeft = new IbbButton(gv, 1.0f);
			    btnInventoryLeft.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small);
			    btnInventoryLeft.Img2 = gv.cc.LoadBitmap("ctrl_left_arrow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.ctrl_left_arrow);
			    btnInventoryLeft.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnInventoryLeft.X = 8 * gv.squareSize;
			    btnInventoryLeft.Y = (1 * gv.squareSize) - (pH * 2);
                btnInventoryLeft.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnInventoryLeft.Width = (int)(gv.ibbwidthR * gv.screenDensity);
		    }
		    if (btnPageIndex == null)
		    {
			    btnPageIndex = new IbbButton(gv, 1.0f);
			    btnPageIndex.Img = gv.cc.LoadBitmap("btn_small_off"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_off);
			    btnPageIndex.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnPageIndex.Text = "1/10";
			    btnPageIndex.X = 9 * gv.squareSize;
			    btnPageIndex.Y = (1 * gv.squareSize) - (pH * 2);
                btnPageIndex.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnPageIndex.Width = (int)(gv.ibbwidthR * gv.screenDensity);
		    }
		    if (btnInventoryRight == null)
		    {
			    btnInventoryRight = new IbbButton(gv, 1.0f);
			    btnInventoryRight.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small);
			    btnInventoryRight.Img2 = gv.cc.LoadBitmap("ctrl_right_arrow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.ctrl_right_arrow);
			    btnInventoryRight.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnInventoryRight.X = 10 * gv.squareSize;
			    btnInventoryRight.Y = (1 * gv.squareSize) - (pH * 2);
                btnInventoryRight.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnInventoryRight.Width = (int)(gv.ibbwidthR * gv.screenDensity);
		    }
		
		    if (btnReturn == null)
		    {
			    btnReturn = new IbbButton(gv, 1.2f);	
			    btnReturn.Text = "RETURN";
			    btnReturn.Img = gv.cc.LoadBitmap("btn_large"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_large);
			    btnReturn.Glow = gv.cc.LoadBitmap("btn_large_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_large_glow);
                btnReturn.X = (gv.screenWidth / 2) - (int)(gv.ibbwidthL * gv.screenDensity / 2.0f);
			    btnReturn.Y = 9 * gv.squareSize + pH * 2;
                btnReturn.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnReturn.Width = (int)(gv.ibbwidthL * gv.screenDensity);			
		    }
		    if (btnHelp == null)
		    {
			    btnHelp = new IbbButton(gv, 0.8f);	
			    btnHelp.Text = "HELP";
			    btnHelp.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small);
			    btnHelp.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnHelp.X = 0 * gv.squareSize + padW * 1 + gv.oXshift;
			    btnHelp.Y = 9 * gv.squareSize + pH * 2;
                btnHelp.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnHelp.Width = (int)(gv.ibbwidthR * gv.screenDensity);			
		    }
		    if (btnInfo == null)
		    {
			    btnInfo = new IbbButton(gv, 0.8f);	
			    btnInfo.Text = "INFO";
			    btnInfo.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small);
			    btnInfo.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnInfo.X = (15 * gv.squareSize) - padW * 1 + gv.oXshift;
			    btnInfo.Y = 9 * gv.squareSize + pH * 2;
                btnInfo.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnInfo.Width = (int)(gv.ibbwidthR * gv.screenDensity);			
		    }
		    for (int y = 0; y < slotsPerPage; y++)
		    {
			    IbbButton btnNew = new IbbButton(gv, 1.0f);	
			    btnNew.Img = gv.cc.LoadBitmap("item_slot"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.item_slot);
			    btnNew.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			
			    if (y < 5)
			    {
				    btnNew.X = ((y+2+4) * gv.squareSize) + (padW * (y+1)) + gv.oXshift;
				    btnNew.Y = 2 * gv.squareSize;
			    }
			    else if ((y >=5 ) && (y < 10))
			    {
				    btnNew.X = ((y-5+2+4) * gv.squareSize) + (padW * ((y-5)+1)) + gv.oXshift;
				    btnNew.Y = 3 * gv.squareSize + padW;
			    }
			    else if ((y >=10 ) && (y < 15))
			    {
				    btnNew.X = ((y-10+2+4) * gv.squareSize) + (padW * ((y-10)+1)) + gv.oXshift;
				    btnNew.Y = 4 * gv.squareSize + (padW * 2);
			    }
			    else
			    {
				    btnNew.X = ((y-15+2+4) * gv.squareSize) + (padW * ((y-15)+1)) + gv.oXshift;
				    btnNew.Y = 5 * gv.squareSize + (padW * 3);
			    }

                btnNew.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnNew.Width = (int)(gv.ibbwidthR * gv.screenDensity);	
			
			    btnInventorySlot.Add(btnNew);
		    }			
	    }
	
	    //INVENTORY SCREEN (COMBAT and MAIN)
        public void redrawInventory()
        {
    	    //IF CONTROLS ARE NULL, CREATE THEM
    	    if (btnReturn == null)
    	    {
    		    setControlsStart();
    	    }
    	
    	    doItemStacking();
    	
    	    int pW = (int)((float)gv.screenWidth / 100.0f);
		    int pH = (int)((float)gv.screenHeight / 100.0f);
		
    	    int locY = 0;
    	    int locX = pW * 4;
    	    int textH = (int)gv.cc.MeasureString("GetHeight", gv.drawFontReg, gv.Width).Height;
            int spacing = textH;
            //int spacing = (int)gv.mSheetTextPaint.getTextSize() + pH;
    	    int tabX = pW * 4;
    	    int tabX2 = 5 * gv.squareSize + pW * 2;
    	    int leftStartY = pH * 4;
    	    int tabStartY = 5 * gv.squareSize + pW * 10;
    	
            //gv.gCanvas.Clear(Color.Black);
    	    //canvas.drawColor(Color.DKGRAY);
		    
		    //DRAW TEXT		
		    locY = gv.squareSize + (pH * 2);
		    //gv.mSheetTextPaint.setColor(Color.LTGRAY);
            gv.DrawText("Party", locX + (gv.squareSize * 5) + pW * 2, locY);
            gv.DrawText("Inventory", locX + (gv.squareSize * 5) + pW * 2, locY += spacing);
		    locY = gv.squareSize + (pH * 2);
		    //gv.mSheetTextPaint.setColor(Color.YELLOW);
            gv.DrawText("Party", tabX2 + (gv.squareSize * 6), locY);
            gv.DrawText("Gold: " + mod.partyGold, tabX2 + (gv.squareSize * 6), locY += spacing);

		    //DRAW LEFT/RIGHT ARROWS and PAGE INDEX
		    btnPageIndex.Draw();
		    btnInventoryLeft.Draw();
		    btnInventoryRight.Draw();		
		
		    //DRAW ALL INVENTORY SLOTS		
		    int cntSlot = 0;
		    foreach (IbbButton btn in btnInventorySlot)
		    {
			    if (cntSlot == inventorySlotIndex) {btn.glowOn = true;}
			    else {btn.glowOn = false;}
			    if ((cntSlot + (inventoryPageIndex * slotsPerPage)) < mod.partyInventoryRefsList.Count)
			    {
				    Item it = mod.getItemByResRefForInfo(mod.partyInventoryRefsList[cntSlot + (inventoryPageIndex * slotsPerPage)].resref);
				    //Item it = mod.partyInventoryRefsList.get(cntSlot + (inventoryPageIndex * slotsPerPage).resref);
				    btn.Img2 = gv.cc.LoadBitmap(it.itemImage);	
				    ItemRefs itr = mod.partyInventoryRefsList[cntSlot + (inventoryPageIndex * slotsPerPage)];
				    if (itr.quantity > 1)
				    {
					    btn.Quantity = itr.quantity + "";
				    }
				    else
				    {
					    btn.Quantity = "";
				    }
			    }
			    else
			    {
				    btn.Img2 = null;
				    btn.Quantity = "";
			    }
			    btn.Draw();
			    cntSlot++;
		    }
		
		    //DRAW DESCRIPTION BOX
		    locY = tabStartY;		
		    if (isSelectedItemSlotInPartyInventoryRange())
		    {
			    ItemRefs itRef = GetCurrentlySelectedItemRefs();
        	    Item it = mod.getItemByResRefForInfo(itRef.resref);

                //Description
		        string textToSpan = "";
                //textToSpan = "Description:" + Environment.NewLine;
        	    //textToSpan += it.name + Environment.NewLine;
                textToSpan = "<u>Description</u>" + "<BR>";
	            textToSpan += "<b><i><big>" + it.name + "</big></i></b><BR>";
	            if ((it.category.Equals("Melee")) || (it.category.Equals("Ranged")))
	            {
	        	    textToSpan += "Damage: " + it.damageNumDice + "d" + it.damageDie + "+" + it.damageAdder + "<BR>";
	                textToSpan += "Attack Bonus: " + it.attackBonus + "<BR>";
	                textToSpan += "Attack Range: " + it.attackRange + "<BR>";
	                textToSpan += "Useable By: " + isUseableBy(it) + "<BR>";
	                textToSpan += "Tap 'INFO' for Full Description<BR>";
	            }    
	            else if (!it.category.Equals("General"))
	            {
	        	    textToSpan += "AC Bonus: " + it.armorBonus + "<BR>";
	                textToSpan += "Max Dex Bonus: " + it.maxDexBonus + "<BR>";
	                textToSpan += "Useable By: " + isUseableBy(it) + "<BR>";
	                textToSpan += "Tap 'INFO' for Full Description<BR>";
	            }
	            else if (it.category.Equals("General"))
	            {
	        	    textToSpan += "Useable By: " + isUseableBy(it) + "<BR>";
	        	    textToSpan += "Tap 'INFO' for Full Description<BR>";
	            }
                //IbRect rect = new IbRect(tabX, locY, pW * 80, pH * 50);
                //gv.DrawText(textToSpan, rect, 1.0f, Color.White);

                description.tbXloc = (11 * gv.squareSize) + (pW * 5) + gv.oXshift;
                description.tbYloc = 2 * gv.squareSize;
                description.tbWidth = pW * 80;
                description.tbHeight = pH * 50;
                description.logLinesList.Clear();
                description.AddHtmlTextToLog(textToSpan);
                description.onDrawLogBox(gv.gCanvas);
		    }
		    btnHelp.Draw();	
		    btnInfo.Draw();	
		    btnReturn.Draw();
        }
        public string isUseableBy(Item it)
        {
    	    string strg = "";
    	    foreach (PlayerClass cls in mod.modulePlayerClassList)
    	    {
                string firstLetter = cls.name.Substring(0,1);
    		    foreach (ItemRefs stg in cls.itemsAllowed)
    		    {
    			    if (stg.resref.Equals(it.resref))
    			    {
    				    strg += firstLetter + ", ";
    			    }
    		    }
    	    }
    	    return strg;
        }
	    public void onTouchInventory(MouseEventArgs e, MouseEventType.EventType eventType, bool inCombat)
	    {
		    btnInventoryLeft.glowOn = false;
		    btnInventoryRight.glowOn = false;
		    btnHelp.glowOn = false;
		    btnInfo.glowOn = false;
		    btnReturn.glowOn = false;
		
		    //int eventAction = event.getAction();
		    switch (eventType)
		    {
		    case MouseEventType.EventType.MouseDown:
		    case MouseEventType.EventType.MouseMove:
			    int x = (int) e.X;
			    int y = (int) e.Y;
			    if (btnInventoryLeft.getImpact(x, y))
			    {
				    btnInventoryLeft.glowOn = true;
			    }
			    else if (btnInventoryRight.getImpact(x, y))
			    {
				    btnInventoryRight.glowOn = true;
			    }
			    else if (btnHelp.getImpact(x, y))
			    {
				    btnHelp.glowOn = true;
			    }
			    else if (btnInfo.getImpact(x, y))
			    {
				    btnInfo.glowOn = true;
			    }
			    else if (btnReturn.getImpact(x, y))
			    {
				    btnReturn.glowOn = true;
			    }
			    break;
			
		    case MouseEventType.EventType.MouseUp:
			    x = (int) e.X;
			    y = (int) e.Y;
			
			    btnInventoryLeft.glowOn = false;
			    btnInventoryRight.glowOn = false;
			    btnHelp.glowOn = false;
			    btnInfo.glowOn = false;
			    btnReturn.glowOn = false;
			
			    for (int j = 0; j < slotsPerPage; j++)
			    {
				    if (btnInventorySlot[j].getImpact(x, y))
				    {
					    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
					    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
					    if (inventorySlotIndex == j)
					    {
						    if (inCombat)
						    {
                                if (isSelectedItemSlotInPartyInventoryRange())
                                {
                                    doItemAction(true);
                                }
						    }
						    else
						    {
                                if (isSelectedItemSlotInPartyInventoryRange())
                                {
                                    doItemAction(false);
                                }
						    }
					    }
					    inventorySlotIndex = j;
				    }
			    }
			    if (btnInventoryLeft.getImpact(x, y))
			    {
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    if (inventoryPageIndex > 0)
				    {
					    inventoryPageIndex--;
					    btnPageIndex.Text = (inventoryPageIndex + 1) + "/10";
				    }
			    }
			    else if (btnInventoryRight.getImpact(x, y))
			    {
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    if (inventoryPageIndex < 9)
				    {
					    inventoryPageIndex++;
					    btnPageIndex.Text = (inventoryPageIndex + 1) + "/10";
				    }
			    }
			    else if (btnHelp.getImpact(x, y))
			    {
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    tutorialMessageInventory(true);
			    }
			    else if (btnInfo.getImpact(x, y))
			    {
				    if (isSelectedItemSlotInPartyInventoryRange())
				    {				
					    ItemRefs itRef = GetCurrentlySelectedItemRefs();
					    if (itRef == null) { return;}
	            	    Item it = mod.getItemByResRef(itRef.resref);
	            	    if (it == null) {return;}
					    gv.sf.ShowFullDescription(it);
				    }				
			    }
			    else if (btnReturn.getImpact(x, y))
			    {
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    if (inCombat)
				    {
					    //gv.currentCombatMode = "info";
					    if (gv.screenCombat.canMove)
					    {
						    gv.screenCombat.currentCombatMode = "move";
					    }
					    else
					    {
						    gv.screenCombat.currentCombatMode = "attack";
					    }
					    //gv.screenCombat.currentCombatMode = "move";
					    gv.screenType = "combat";
					    doCleanUp();
				    }
				    else
				    {
					    gv.screenType = "main";	
					    doCleanUp();
				    }							
			    }
			    break;		
		    }
	    }
	
	    public void doCleanUp()
	    {
		    btnInventorySlot.Clear();
		    btnInventoryLeft = null;
		    btnInventoryRight = null;
		    btnPageIndex = null;
		    btnHelp = null;
		    btnInfo = null;
		    btnReturn = null;
	    }
	
	    public void doItemAction(bool inCombat)
	    {
            List<string> actionList = new List<string> { "Use Item", "Drop Item", "View Item Description" };

            using (ItemListSelector itSel = new ItemListSelector(gv, actionList, "Item Action"))
            {
                itSel.IceBlinkButtonClose.Enabled = true;
                itSel.IceBlinkButtonClose.Visible = true;
                itSel.setupAll(gv);
                var ret = itSel.ShowDialog();
                ItemRefs itRef = GetCurrentlySelectedItemRefs();
	            Item it = mod.getItemByResRefForInfo(itRef.resref);
                if ((itSel.selectedIndex == 0) && ( (!it.onUseItem.Equals("none")) || (!it.onUseItemLogicTree.Equals("none")) ) )
                {                    
	            	// selected to USE ITEM
	            	List<string> pcNames = new List<string>();
	                pcNames.Add("cancel");
	                if (inCombat)
	                {
	                    Player pc = mod.playerList[gv.screenCombat.currentPlayerIndex];
	                    pcNames.Add(pc.name);
	                }
	                else
	                {
		                foreach (Player pc in mod.playerList)
		                {
		                    pcNames.Add(pc.name);
		                }	   
	                }
                    using (ItemListSelector itSel2 = new ItemListSelector(gv, pcNames, "Selected PC to Use Item"))
                    {
                        itSel2.IceBlinkButtonClose.Enabled = true;
                        itSel2.IceBlinkButtonClose.Visible = true;
                        itSel2.setupAll(gv);
                        var ret2 = itSel2.ShowDialog();
                        if (itSel2.selectedIndex > 0)
                        {
                            try
		                    {
		                		itRef = GetCurrentlySelectedItemRefs();
		            	        it = mod.getItemByResRefForInfo(itRef.resref);
		                		if (inCombat)
		                		{
		                			//check to see if use logic tree first
		                			if (!it.onUseItem.Equals("none"))
		                			{
			                			Player pc = mod.playerList[gv.screenCombat.currentPlayerIndex];
			                			doItemInventoryScriptBasedOnFilename(pc);
			                			gv.screenCombat.currentCombatMode = "move";
			                			gv.screenType = "combat";
			                			gv.screenCombat.endPcTurn(false);
		                			}
		                			else if (!it.onUseItemLogicTree.Equals("none"))
		                			{
		                				doItemInventoryLogicTree(gv.screenCombat.currentPlayerIndex);
		                				gv.screenCombat.currentCombatMode = "move";
			                			gv.screenType = "combat";
			                			gv.screenCombat.endPcTurn(false);
		                			}
		                						
		                		}
		                		else
		                		{
		                			//check to see if use logic tree first
		                			if (!it.onUseItem.Equals("none"))
		                			{
			                			Player pc = mod.playerList[itSel2.selectedIndex - 1];
			                			doItemInventoryScriptBasedOnFilename(pc);
		                			}
		                			else if (!it.onUseItemLogicTree.Equals("none"))
		                			{
		                				doItemInventoryLogicTree(itSel2.selectedIndex - 1);
		                			}
		                		}
		                    }
		                    catch (Exception ex)
		                    {
		                        //print error
		                    } 
                        }
                    }
                }	                
	            else if (itSel.selectedIndex == 1) // selected to DROP ITEM
	            {	                		
	            	DialogResult dlg = IBMessageBox.Show(gv, "Do you wish to drop this item forever?", enumMessageButton.YesNo);
                    if (dlg == DialogResult.Yes)
                    {
                        //drop item
	    	            itRef = GetCurrentlySelectedItemRefs();
	    	            it = mod.getItemByResRef(itRef.resref);
	    	            if (!it.plotItem)
	    	            {
		    	            gv.sf.RemoveItemFromInventory(itRef, 1);
	    	            }
	    	            else
	    	            {
	    	                gv.sf.MessageBoxHtml("You can't drop this item.");
	    	            }
                    }
	            }
	            else if (itSel.selectedIndex == 2) // selected to VIEW ITEM
	            {
	            	gv.sf.ShowFullDescription(it);
	            }                                
            }
		    /*if (isSelectedItemSlotInPartyInventoryRange())
		    {
			    if (dialogOpen)
	    	    {
	    		    return;
	    	    }
	    	    dialogOpen = true;
			    // Strings to Show In Dialog with Radio Buttons
			    final CharSequence[] items = {" Use Item "," Drop Item "," View Item Description "};				            
	            // Creating and Building the Dialog 
	            AlertDialog.Builder builder = new AlertDialog.Builder(gv.gameContext);
	            builder.setTitle("Item Action");
	            builder.setOnCancelListener(new DialogInterface.OnCancelListener() 
	            {			
				    @Override
				    public void onCancel(DialogInterface dialog) 
				    {
					    dialogOpen = false;
				    }
			    });
	            builder.setItems(items, new DialogInterface.OnClickListener() 
	            {
	                public void onClick(DialogInterface dialog, int item) 
	                {
	            	    ItemRefs itRef = GetCurrentlySelectedItemRefs();
	            	    Item it = mod.getItemByResRefForInfo(itRef.resref);
	            	    //Item it = mod.partyInventoryList.get(filteredInventoryIndexList.get(partyInventoryItemIndex));
	            	    //if ((item == 0) && (!mod.partyInventoryList.get(partyInventoryItemIndex).onUseItem.equals("none")))
	            	    if ( (item == 0) && ( (!it.onUseItem.equals("none")) || (!it.onUseItemLogicTree.equals("none")) ) )
	            	    {	      
	            		    // selected to USE ITEM
	            		    List<String> pcNames = new ArrayList<String>();
	                        pcNames.add("cancel");
	                        if (inCombat)
	                        {
	                    	    Player pc = mod.playerList.get(gv.screenCombat.currentPlayerIndex);
	                            pcNames.add(pc.name);
	                        }
	                        else
	                        {
		                        for (Player pc : mod.playerList)
		                        {
		                    	    pcNames.add(pc.name);
		                        }	   
	                        }
	                        final CharSequence[] items = pcNames.toArray(new CharSequence[pcNames.size()]);
	                        // Creating and Building the Dialog 
	                        AlertDialog.Builder builder = new AlertDialog.Builder(gv.gameContext);
	                        builder.setTitle("Select the PC to use the Item");
	                        builder.setItems(items, new DialogInterface.OnClickListener() 
	                        {
	    	                    public void onClick(DialogInterface dialog, int item) 
	    	                    {
	    	                	    if (item > 0)
	    	                	    {	        	                		
		                			    try
		                                {
		                				    ItemRefs itRef = GetCurrentlySelectedItemRefs();
		            	            	    Item it = mod.getItemByResRefForInfo(itRef.resref);
		                				    if (inCombat)
		                				    {
		                					    //check to see if use logic tree first
		                					    if (!it.onUseItem.equals("none"))
		                					    {
			                					    Player pc = mod.playerList.get(gv.screenCombat.currentPlayerIndex);
			                					    doItemInventoryScriptBasedOnFilename(pc);
			                					    gv.screenCombat.currentCombatMode = "move";
			                					    gv.screenType = "combat";
			                					    gv.screenCombat.endPcTurn(false);
		                					    }
		                					    else if (!it.onUseItemLogicTree.equals("none"))
		                					    {
		                						    doItemInventoryLogicTree(gv.screenCombat.currentPlayerIndex);
		                						    gv.screenCombat.currentCombatMode = "move";
			                					    gv.screenType = "combat";
			                					    gv.screenCombat.endPcTurn(false);
		                					    }
		                						
		                				    }
		                				    else
		                				    {
		                					    //check to see if use logic tree first
		                					    if (!it.onUseItem.equals("none"))
		                					    {
			                					    Player pc = mod.playerList.get(item - 1);
			                					    doItemInventoryScriptBasedOnFilename(pc);
		                					    }
		                					    else if (!it.onUseItemLogicTree.equals("none"))
		                					    {
		                						    doItemInventoryLogicTree(item - 1);
		                					    }
		                				    }
		                                }
		                                catch (Exception ex)
		                                {
		                                    //print error
		                                }        	                            	        	                        
	    	                	    }
	    	                	    else if (item == 0) // selected "cancel"
	    	                	    {
	    	                		    //do nothing
	    	                	    }
	    	                	    gv.ActionDialog.dismiss();
	    	                	    gv.invalidate();
	    	                    }
	                        });
	                        gv.ActionDialog = builder.create();
	                        gv.ActionDialog.show();
	            	    }
	            	    else if (item == 1) // selected to DROP ITEM
	            	    {	                		
	            		    //drop item
	            		    final CharSequence[] items = {" YES "," NO "};				            
	                        AlertDialog.Builder builder = new AlertDialog.Builder(gv.gameContext);
	                        builder.setTitle("Are you sure you wish to drop the item forever?");
	                        builder.setItems(items, new DialogInterface.OnClickListener() 
	                        {
	    	                    public void onClick(DialogInterface dialog, int item) 
	    	                    {
	    	                	    if (item == 0) // selected YES
	    	                	    {	                		
	    	                		    //drop item
	    	                		    ItemRefs itRef = GetCurrentlySelectedItemRefs();
	    	                		    Item it = mod.getItemByResRef(itRef.resref);
	    	                		    if (!it.plotItem)
	    	                		    {
		    	                		    //Item it = mod.partyInventoryList.get(filteredInventoryIndexList.get(partyInventoryItemIndex));
		    	                		    //mod.partyInventoryList.remove(it);
	    	                			    gv.sf.RemoveItemFromInventory(itRef, 1);
		    	                            //mod.partyInventoryRefsList.remove(itRef);
		    	                            //partyInventoryItemIndex = 0;
	    	                		    }
	    	                		    else
	    	                		    {
	    	                			    gv.sf.MessageBoxHtml("You can't drop this item.");
	    	                		    }
	    	                	    }
	    	                	    else if (item == 1) // selected NO
	    	                	    {	                		
	    	                		    //do nothing
	    	                	    }
	    	                	    gv.ActionDialog.dismiss();
	    	                	    gv.invalidate();
	    	                    }
	                        });
	                        gv.ActionDialog = builder.create();
	                        gv.ActionDialog.show();
	            	    }
	            	    else if (item == 2) // selected to VIEW ITEM
	            	    {
	            		    gv.sf.ShowFullDescription(it);
	            	    }
	            	    dialogOpen = false;
	            	    gv.ItemDialog.dismiss();
	            	    gv.invalidate();
	                }
	            });
	            gv.ItemDialog = builder.create();
	            gv.ItemDialog.show();
		    }*/
	    }
	    public void doItemInventoryScriptBasedOnFilename(Player pc)
        {
    	    if (isSelectedItemSlotInPartyInventoryRange())
		    {
    		    ItemRefs itRef = GetCurrentlySelectedItemRefs();
        	    gv.cc.doItemScriptBasedOnUseItem(pc, itRef, true);	    	
		    }
        }
	    public void doItemInventoryLogicTree(int pcIndex)
        {
    	    if (isSelectedItemSlotInPartyInventoryRange())
		    {
    		    ItemRefs itRef = GetCurrentlySelectedItemRefs();
    		    Item it = gv.mod.getItemByResRefForInfo(itRef.resref);
    		    gv.cc.currentPlayerIndexUsingItem = pcIndex;
    		    gv.cc.doLogicTreeBasedOnTag(it.onUseItemLogicTree, it.onUseItemLogicTreeParms);
    		    if (it.destroyItemAfterOnUseItemLogicTree)
        	    {
        		    gv.sf.RemoveItemFromInventory(itRef, 1);
        	    }	    	
		    }
        }
	    public int GetIndex()
	    {
		    return inventorySlotIndex + (inventoryPageIndex * slotsPerPage);
	    }
	
	    public void doItemStacking()
	    {
		    for (int i = 0; i < mod.partyInventoryRefsList.Count; i++)
		    {
			    ItemRefs itr = mod.partyInventoryRefsList[i];
			    Item itm = mod.getItemByResRefForInfo(itr.resref);
			    if (itm.isStackable)
			    {
				    for (int j = mod.partyInventoryRefsList.Count - 1; j >= 0; j--)
				    {
					    ItemRefs it = mod.partyInventoryRefsList[j];
					    //do check to see if same resref and then stack and delete
					    if ((it.resref.Equals(itr.resref)) && (i != j))
					    {
						    itr.quantity += it.quantity;
						    mod.partyInventoryRefsList.RemoveAt(j);
					    }
				    }
			    }
		    }
	    }
	    public ItemRefs GetCurrentlySelectedItemRefs()
	    {
		    return mod.partyInventoryRefsList[GetIndex()];
	    }
	    public bool isSelectedItemSlotInPartyInventoryRange()
	    {
		    return GetIndex() < mod.partyInventoryRefsList.Count;
	    }
	    public void tutorialMessageInventory(bool helpCall)
        {
    	    if ((mod.showTutorialInventory) || (helpCall))
		    {
    		    gv.sf.MessageBoxHtml(gv.cc.stringMessageInventory);    		
			    mod.showTutorialInventory = false;
		    }
        }
    }
}
