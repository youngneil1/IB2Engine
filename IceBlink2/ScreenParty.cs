﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IceBlink2
{
    public class ScreenParty 
    {
	    public Module mod;
	    public GameView gv;
        private IbbHtmlTextBox description;

	    public List<IbbButton> btnPartyIndex = new List<IbbButton>();
	    private IbbButton btnHead = null;
	    private IbbButton btnNeck = null;
	    private IbbButton btnBody = null;
	    private IbbButton btnMainHand = null;
	    private IbbButton btnOffHand = null;
	    private IbbButton btnRing = null;
	    private IbbButton btnRing2 = null;
	    private IbbButton btnFeet = null;
	    private IbbButton btnAmmo = null;
	    private IbbButton btnHelp = null;
	    private IbbButton btnInfo = null;
	    private IbbButton btnReturn = null;
	    private IbbButton btnLevelUp = null;
        private IbbButton btnPartyRoster = null;
	    private IbbButton btnSpells = null;
	    private IbbButton btnTraits = null;
	    private IbbButton btnEffects = null;
	    private IbbButton btnOthers = null;
	    private bool dialogOpen = false;
	    public string traitGained = "";
	    public string spellGained = "";
	
	
        public ScreenParty(Module m, GameView g)
	    {
		    mod = m;
		    gv = g;
		    setControlsStart();
            description = new IbbHtmlTextBox(gv, 320, 100, 500, 300);
            description.showBoxBorder = false;
	    }    
	
        public void setControlsStart()
	    {		
    	    int pW = (int)((float)gv.screenWidth / 100.0f);
		    int pH = (int)((float)gv.screenHeight / 100.0f);
		    int padW = gv.squareSize/6;
		
		    if (btnSpells == null)
		    {
			    btnSpells = new IbbButton(gv, 0.6f);	
			    btnSpells.Text = "SPELLS";
			    btnSpells.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small);
			    btnSpells.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnSpells.X = 5 * gv.squareSize + padW * 1 + gv.oXshift;
			    //btnSpells.Y = 10 * gv.squareSize + pH * 2; See OnDraw for Y
                btnSpells.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnSpells.Width = (int)(gv.ibbwidthR * gv.screenDensity);			
		    }
		    if (btnTraits == null)
		    {
			    btnTraits = new IbbButton(gv, 0.6f);	
			    btnTraits.Text = "TRAITS";
			    btnTraits.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small);
			    btnTraits.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnTraits.X = 6 * gv.squareSize + padW * 2 + gv.oXshift;
			    //btnSpells.Y = 10 * gv.squareSize + pH * 2; See OnDraw for Y
                btnTraits.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnTraits.Width = (int)(gv.ibbwidthR * gv.screenDensity);			
		    }
		    if (btnEffects == null)
		    {
			    btnEffects = new IbbButton(gv, 0.6f);	
			    btnEffects.Text = "EFFECTS";
			    btnEffects.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small);
			    btnEffects.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnEffects.X = 7 * gv.squareSize + padW * 3 + gv.oXshift;
			    //btnSpells.Y = 10 * gv.squareSize + pH * 2; See OnDraw for Y
                btnEffects.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnEffects.Width = (int)(gv.ibbwidthR * gv.screenDensity);			
		    }
		    if (btnOthers == null)
		    {
			    btnOthers = new IbbButton(gv, 0.6f);	
			    btnOthers.Text = "OTHERS";
			    btnOthers.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small);
			    btnOthers.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnOthers.X = 8 * gv.squareSize + padW * 4 + gv.oXshift;
			    //btnSpells.Y = 10 * gv.squareSize + pH * 2; See OnDraw for Y
                btnOthers.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnOthers.Width = (int)(gv.ibbwidthR * gv.screenDensity);			
		    }
            if (btnPartyRoster == null)
            {
                btnPartyRoster = new IbbButton(gv, 0.6f);
                btnPartyRoster.Text = "ROSTER";
                btnPartyRoster.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small);
                btnPartyRoster.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
                btnPartyRoster.X = 10 * gv.squareSize + (gv.squareSize/2) + gv.oXshift;
                btnPartyRoster.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnPartyRoster.Width = (int)(gv.ibbwidthR * gv.screenDensity);
            }
		    if (btnHelp == null)
		    {
			    btnHelp = new IbbButton(gv, 0.8f);	
			    btnHelp.Text = "HELP";
			    btnHelp.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small);
			    btnHelp.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnHelp.X = 5 * gv.squareSize + padW * 1 + gv.oXshift;
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
		    if (btnLevelUp == null)
		    {
			    btnLevelUp = new IbbButton(gv, 1.2f);	
			    btnLevelUp.Img = gv.cc.LoadBitmap("btn_large"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_large);
			    btnLevelUp.Glow = gv.cc.LoadBitmap("btn_large_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_large_glow);
			    btnLevelUp.Text = "Level Up";
                btnLevelUp.X = 8 * gv.squareSize + padW * 4 + gv.oXshift;
			    btnLevelUp.Y = pH * 4;
                btnLevelUp.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnLevelUp.Width = (int)(gv.ibbwidthL * gv.screenDensity);			
		    }
		
		    if (btnMainHand == null)
		    {
			    btnMainHand = new IbbButton(gv, 1.0f);	
			    btnMainHand.Img = gv.cc.LoadBitmap("item_slot_mainhand"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.item_slot_mainhand);
			    btnMainHand.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnMainHand.X = 5 * gv.squareSize + (padW * 1) + gv.oXshift;
			    btnMainHand.Y = 2 * gv.squareSize; //not used, see onDraw function
                btnMainHand.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnMainHand.Width = (int)(gv.ibbwidthR * gv.screenDensity);
		    }
		    if (btnHead == null)
		    {
			    btnHead = new IbbButton(gv, 1.0f);	
			    btnHead.Img = gv.cc.LoadBitmap("item_slot_head"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.item_slot_head);
			    btnHead.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnHead.X = 6 * gv.squareSize + (padW * 2) + gv.oXshift;
			    btnHead.Y = 2 * gv.squareSize; //not used, see onDraw function
                btnHead.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnHead.Width = (int)(gv.ibbwidthR * gv.screenDensity);
		    }
		    if (btnNeck == null)
		    {
			    btnNeck = new IbbButton(gv, 1.0f);	
			    btnNeck.Img = gv.cc.LoadBitmap("item_slot_neck"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.item_slot_neck);
			    btnNeck.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnNeck.X = 7 * gv.squareSize + (padW * 3) + gv.oXshift;
			    btnNeck.Y = 2 * gv.squareSize; //not used, see onDraw function
                btnNeck.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnNeck.Width = (int)(gv.ibbwidthR * gv.screenDensity);
		    }
		    if (btnOffHand == null)
		    {
			    btnOffHand = new IbbButton(gv, 1.0f);	
			    btnOffHand.Img = gv.cc.LoadBitmap("item_slot_offhand"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.item_slot_offhand);
			    btnOffHand.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnOffHand.X = 8 * gv.squareSize + (padW * 4) + gv.oXshift;
			    btnOffHand.Y = 2 * gv.squareSize; //not used, see onDraw function
                btnOffHand.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnOffHand.Width = (int)(gv.ibbwidthR * gv.screenDensity);
		    }
		    if (btnRing == null)
		    {
			    btnRing = new IbbButton(gv, 1.0f);	
			    btnRing.Img = gv.cc.LoadBitmap("item_slot_ring"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.item_slot_ring);
			    btnRing.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnRing.X = 5 * gv.squareSize + (padW * 1) + gv.oXshift;
			    btnRing.Y = 2 * gv.squareSize; //not used, see onDraw function
                btnRing.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnRing.Width = (int)(gv.ibbwidthR * gv.screenDensity);
		    }
		    if (btnBody == null)
		    {
			    btnBody = new IbbButton(gv, 1.0f);	
			    btnBody.Img = gv.cc.LoadBitmap("item_slot_body"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.item_slot_body);
			    btnBody.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnBody.X = 6 * gv.squareSize + (padW * 2) + gv.oXshift;
			    btnBody.Y = 2 * gv.squareSize; //not used, see onDraw function
                btnBody.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnBody.Width = (int)(gv.ibbwidthR * gv.screenDensity);
		    }
		    if (btnFeet == null)
		    {
			    btnFeet = new IbbButton(gv, 1.0f);	
			    btnFeet.Img = gv.cc.LoadBitmap("item_slot_feet"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.item_slot_feet);
			    btnFeet.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnFeet.X = 7 * gv.squareSize + (padW * 3) + gv.oXshift;
			    btnFeet.Y = 2 * gv.squareSize; //not used, see onDraw function
                btnFeet.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnFeet.Width = (int)(gv.ibbwidthR * gv.screenDensity);
		    }
		    if (btnRing2 == null)
		    {
			    btnRing2 = new IbbButton(gv, 1.0f);	
			    btnRing2.Img = gv.cc.LoadBitmap("item_slot_ring"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.item_slot_ring);
			    btnRing2.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnRing2.X = 8 * gv.squareSize + (padW * 4) + gv.oXshift;
			    btnRing2.Y = 3 * gv.squareSize + padW; //not used, see onDraw function
                btnRing2.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnRing2.Width = (int)(gv.ibbwidthR * gv.screenDensity);
		    }
		    if (btnAmmo == null)
		    {
			    btnAmmo = new IbbButton(gv, 1.0f);	
			    btnAmmo.Img = gv.cc.LoadBitmap("item_slot_ammo"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.item_slot_ring);
			    btnAmmo.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnAmmo.X = 9 * gv.squareSize + (padW * 5) + gv.oXshift;
			    btnAmmo.Y = 3 * gv.squareSize + padW; //not used, see onDraw function
                btnAmmo.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnAmmo.Width = (int)(gv.ibbwidthR * gv.screenDensity);
		    }
				
		    for (int x = 0; x < 6; x++)
		    {
			    IbbButton btnNew = new IbbButton(gv, 1.0f);	
			    btnNew.Img = gv.cc.LoadBitmap("item_slot"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.item_slot);
			    btnNew.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnNew.X = ((x+5) * gv.squareSize) + (padW * (x+1)) + gv.oXshift;
			    btnNew.Y = pH * 2;
                btnNew.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnNew.Width = (int)(gv.ibbwidthR * gv.screenDensity);	
			
			    btnPartyIndex.Add(btnNew);
		    }
	    }
	
	    //PARTY SCREEN
        public void redrawParty()
        {    	
            
    	    if (gv.cc.partyScreenPcIndex >= mod.playerList.Count)
    	    {
    		    gv.cc.partyScreenPcIndex = 0;
    	    }
    	    Player pc = mod.playerList[gv.cc.partyScreenPcIndex];
    	    gv.sf.UpdateStats(pc);
    	    int pW = (int)((float)gv.screenWidth / 100.0f);
		    int pH = (int)((float)gv.screenHeight / 100.0f);
		    int padH = gv.squareSize/6;
    	    int locY = 0;
    	    int locX = pW * 4;
            int textH = (int)gv.cc.MeasureString("GetHeight", gv.drawFontReg, gv.Width).Height;
            int spacing = textH;
    	    //int spacing = (int)gv.mSheetTextPaint.getTextSize() + pH;
    	    int tabX = pW * 50;
    	    int tabX2 = pW * 70;
    	    int leftStartY = btnPartyIndex[0].Y + btnPartyIndex[0].Height + (pH * 4);
		
            //gv.gCanvas.Clear(Color.DarkGray);
		    //canvas.drawColor(Color.DKGRAY);
		
		    //DRAW EACH PC BUTTON
		    int cntPCs = 0;
		    foreach (IbbButton btn in btnPartyIndex)
		    {
			    if (cntPCs < mod.playerList.Count)
			    {
				    if (cntPCs == gv.cc.partyScreenPcIndex) {btn.glowOn = true;}
				    else {btn.glowOn = false;}					
				    btn.Draw();
			    }
			    cntPCs++;
		    }
				
		    //DRAW LEFT STATS
            //name            
            gv.DrawText("Name: " + pc.name, locX, locY += leftStartY, 1.0f, Color.White);

		    //race
            gv.DrawText("Race: " + mod.getRace(pc.raceTag).name, locX, locY += spacing, 1.0f, Color.White);

		    //gender
            if (pc.isMale)
		    {
                gv.DrawText("Gender: Male", locX, locY += spacing, 1.0f, Color.White);
		    }
		    else
		    {
                gv.DrawText("Gender: Female", locX, locY += spacing, 1.0f, Color.White);
		    }
		
		    //class
            gv.DrawText("Class: " + mod.getPlayerClass(pc.classTag).name, locX, locY += spacing, 1.0f, Color.White);
            gv.DrawText("Level: " + pc.classLevel, locX, locY += spacing, 1.0f, Color.White);
		    gv.DrawText("XP: " + pc.XP + "/" + pc.XPNeeded, locX, locY += spacing, 1.0f, Color.White);
		    gv.DrawText("---------------", locX, locY += spacing, 1.0f, Color.White);

		    btnSpells.Y = locY + (pH * 0);
		    btnTraits.Y = locY + (pH * 0);
		    btnEffects.Y = locY + (pH * 0);
		    btnOthers.Y = locY + (pH * 0);
            btnPartyRoster.Y = locY + (pH * 0);
		    
            //DRAW EQUIPMENT SLOTS
		    int startSlotsY = locY + gv.squareSize + padH;
		    btnHead.Y = startSlotsY;
		    btnNeck.Y = startSlotsY;		
		    btnMainHand.Y = startSlotsY;
		    btnOffHand.Y = startSlotsY;
		    btnAmmo.Y = startSlotsY;
		    int startSlotsY2 = startSlotsY + gv.squareSize + padH;
		    btnRing.Y = startSlotsY2;
		    btnRing2.Y = startSlotsY2;
		    btnBody.Y = startSlotsY2;
		    btnFeet.Y = startSlotsY2;		
		
		    if (gv.cc.partyItemSlotIndex == 0) { btnMainHand.glowOn = true; }
		    else { btnMainHand.glowOn = false; }
		    if (gv.cc.partyItemSlotIndex == 1) { btnHead.glowOn = true; }
		    else { btnHead.glowOn = false; }
		    if (gv.cc.partyItemSlotIndex == 2) { btnNeck.glowOn = true; }
		    else { btnNeck.glowOn = false; }
		    if (gv.cc.partyItemSlotIndex == 3) { btnOffHand.glowOn = true; }
		    else { btnOffHand.glowOn = false; }
		    if (gv.cc.partyItemSlotIndex == 4) { btnRing.glowOn = true; }
		    else { btnRing.glowOn = false; }
		    if (gv.cc.partyItemSlotIndex == 5) { btnBody.glowOn = true; }
		    else { btnBody.glowOn = false; }
		    if (gv.cc.partyItemSlotIndex == 6) { btnFeet.glowOn = true; }
		    else { btnFeet.glowOn = false; }		
		    if (gv.cc.partyItemSlotIndex == 7) { btnRing2.glowOn = true; }
		    else { btnRing2.glowOn = false; }
		    if (gv.cc.partyItemSlotIndex == 8) { btnAmmo.glowOn = true; }
		    else { btnAmmo.glowOn = false; }
		
		    btnMainHand.Img2 = gv.cc.LoadBitmap(mod.getItemByResRefForInfo(pc.MainHandRefs.resref).itemImage);
		    btnHead.Img2 = gv.cc.LoadBitmap(mod.getItemByResRefForInfo(pc.HeadRefs.resref).itemImage);
		    btnNeck.Img2 = gv.cc.LoadBitmap(mod.getItemByResRefForInfo(pc.NeckRefs.resref).itemImage);		
		    btnOffHand.Img2 = gv.cc.LoadBitmap(mod.getItemByResRefForInfo(pc.OffHandRefs.resref).itemImage);
		    btnRing.Img2 = gv.cc.LoadBitmap(mod.getItemByResRefForInfo(pc.RingRefs.resref).itemImage);
		    btnBody.Img2 = gv.cc.LoadBitmap(mod.getItemByResRefForInfo(pc.BodyRefs.resref).itemImage);
		    btnFeet.Img2 = gv.cc.LoadBitmap(mod.getItemByResRefForInfo(pc.FeetRefs.resref).itemImage);
		    btnRing2.Img2 = gv.cc.LoadBitmap(mod.getItemByResRefForInfo(pc.Ring2Refs.resref).itemImage);
		    btnAmmo.Img2 = gv.cc.LoadBitmap(mod.getItemByResRefForInfo(pc.AmmoRefs.resref).itemImage);
		
		    ItemRefs itr = mod.getItemRefsInInventoryByResRef(pc.AmmoRefs.resref);
		    if (itr != null)
		    {
			    btnAmmo.Quantity = itr.quantity + "";			
		    }
		    else
		    {
			    btnAmmo.Quantity = "";
		    }
		
		    btnMainHand.Draw();
		    btnHead.Draw();	
		    btnNeck.Draw();	
		    btnOffHand.Draw();
		    btnRing.Draw();
		    btnBody.Draw();	
		    btnFeet.Draw();	
		    btnRing2.Draw();
		    btnAmmo.Draw();
		    btnSpells.Draw();
		    btnTraits.Draw();
		    btnEffects.Draw();
		    btnOthers.Draw();
            btnPartyRoster.Draw();
		
            //DRAW RIGHT STATS
            locY = 0;
		    gv.DrawText("STR: " + pc.strength, tabX, locY += leftStartY);
		    gv.DrawText("AC: " + pc.AC, tabX2, locY);
		    gv.DrawText("DEX: " + pc.dexterity, tabX, locY += spacing);
		    gv.DrawText("HP: " + pc.hp + "/" + pc.hpMax, tabX2, locY);
		    gv.DrawText("INT: " + pc.intelligence, tabX, locY += spacing);
		    gv.DrawText("SP: " + pc.sp + "/" + pc.spMax, tabX2, locY);
		    gv.DrawText("CHA: " + pc.charisma, tabX, locY += spacing);
		    gv.DrawText("BAB: " + pc.baseAttBonus, tabX2, locY);
		
		    //DRAW LEVEL UP BUTTON
		    btnLevelUp.Y = locY + (pH * 1);
		    btnLevelUp.X = tabX - (pW * 5);
		    if (mod.playerList[gv.cc.partyScreenPcIndex].IsReadyToAdvanceLevel())
		    {
			    btnLevelUp.Draw();
		    }
		
		    //DRAW DESCRIPTION BOX
		    Item it = new Item();
		    if (gv.cc.partyItemSlotIndex == 0) { it = mod.getItemByResRefForInfo(pc.MainHandRefs.resref);}
		    else if (gv.cc.partyItemSlotIndex == 1) { it = mod.getItemByResRefForInfo(pc.HeadRefs.resref);}
		    else if (gv.cc.partyItemSlotIndex == 2) { it = mod.getItemByResRefForInfo(pc.NeckRefs.resref);}
		    else if (gv.cc.partyItemSlotIndex == 3) { it = mod.getItemByResRefForInfo(pc.OffHandRefs.resref);}
		    else if (gv.cc.partyItemSlotIndex == 4) { it = mod.getItemByResRefForInfo(pc.RingRefs.resref);}
		    else if (gv.cc.partyItemSlotIndex == 5) { it = mod.getItemByResRefForInfo(pc.BodyRefs.resref);}
		    else if (gv.cc.partyItemSlotIndex == 6) { it = mod.getItemByResRefForInfo(pc.FeetRefs.resref);}
		    else if (gv.cc.partyItemSlotIndex == 7) { it = mod.getItemByResRefForInfo(pc.Ring2Refs.resref);}
		    else if (gv.cc.partyItemSlotIndex == 8) { it = mod.getItemByResRefForInfo(pc.AmmoRefs.resref);}
		
            //Description
		    string textToSpan = "";
            textToSpan = "<u>Description</u>" + "<BR>";
            textToSpan += "<b><i><big>" + it.name + "</big></i></b><BR>";
            //textToSpan = "Description:<br>";
        	//textToSpan += it.name + "<br>";
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
            locY = btnBody.Y + btnBody.Height + (pH * 2);
            //IbRect rect = new IbRect(locX, locY, pW * 80, pH * 50);
            //gv.DrawText(textToSpan, rect, 1.0f, Color.White);

            //string textToSpan = "<u>Module Description</u>" + "<br><br>";
            //textToSpan += "<b><i><big>" + moduleList[moduleIndex].moduleLabelName + "</big></i></b><br>";
            //textToSpan += moduleList[moduleIndex].moduleDescription;
            description.tbXloc = (12 * gv.squareSize) + (pW * 5) + gv.oXshift;
            description.tbYloc = startSlotsY;
            description.tbWidth = pW * 80;
            description.tbHeight = pH * 50;
            description.logLinesList.Clear();
            description.AddHtmlTextToLog(textToSpan);
            description.onDrawLogBox(gv.gCanvas);
            		    
            btnHelp.Draw();
            btnInfo.Draw();
            btnReturn.Draw();        
        }
        public void onTouchParty(MouseEventArgs e, MouseEventType.EventType eventType, bool inCombat)
	    {
		    btnLevelUp.glowOn = false;
            btnPartyRoster.glowOn = false;
		    btnHelp.glowOn = false;
		    btnInfo.glowOn = false;
		    btnReturn.glowOn = false;
		    btnSpells.glowOn = false;
		    btnTraits.glowOn = false;
		    btnEffects.glowOn = false;
		    btnOthers.glowOn = false;
		
		    //int eventAction = event.getAction();
		    switch (eventType)
		    {
		    case MouseEventType.EventType.MouseDown:
		    case MouseEventType.EventType.MouseMove:
			    int x = (int) e.X;
			    int y = (int) e.Y;

			    if (btnLevelUp.getImpact(x, y))
			    {
				    btnLevelUp.glowOn = true;
			    }
                else if (btnPartyRoster.getImpact(x, y))
                {
                    btnPartyRoster.glowOn = true;
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
			    else if (btnSpells.getImpact(x, y))
			    {
				    btnSpells.glowOn = true;
			    }
			    else if (btnTraits.getImpact(x, y))
			    {
				    btnTraits.glowOn = true;
			    }
			    else if (btnEffects.getImpact(x, y))
			    {
				    btnEffects.glowOn = true;
			    }
			    else if (btnOthers.getImpact(x, y))
			    {
				    btnOthers.glowOn = true;
			    }
			    break;
			
		    case MouseEventType.EventType.MouseUp:
			    x = (int) e.X;
			    y = (int) e.Y;
			
			    btnLevelUp.glowOn = false;
                btnPartyRoster.glowOn = false;
			    btnHelp.glowOn = false;
			    btnInfo.glowOn = false;
			    btnReturn.glowOn = false;
			    btnSpells.glowOn = false;
			    btnTraits.glowOn = false;
			    btnEffects.glowOn = false;
			    btnOthers.glowOn = false;
			
			    Player pc = mod.playerList[gv.cc.partyScreenPcIndex];
			
			    if (btnSpells.getImpact(x, y))
			    {
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    string spellList = "";
				    foreach (string s in pc.knownSpellsTags)
				    {
					    Spell sp = mod.getSpellByTag(s);
					    spellList += sp.name + "<br>";					
				    }
				    gv.sf.MessageBoxHtml("<big><b>KNOWN SPELLS</b></big><br><br>" + spellList);
			    }	
			    else if (btnTraits.getImpact(x, y))
			    {
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    string traitList = "";
				    foreach (string s in pc.knownTraitsTags)
				    {
					    Trait tr = mod.getTraitByTag(s);
					    traitList += tr.name + "<br>";					
				    }
				    gv.sf.MessageBoxHtml("<big><b>KNOWN TRAITS</b></big><br><br>" + traitList);
			    }
			    else if (btnEffects.getImpact(x, y))
			    {
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    string allEffects = "";
				    foreach (Effect ef in pc.effectsList)
				    {
					    int left = ef.durationInUnits - ef.currentDurationInUnits;
					    allEffects += ef.name + " (" + left + ")" + "<br>";
				    }
				    gv.sf.MessageBoxHtml("<big><b>CURRENT EFFECTS</b></big><br><b><small>(#) denotes effect time left</small></b><br><br>" + allEffects);
			    }
			    else if (btnOthers.getImpact(x, y))
			    {
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    gv.sf.MessageBoxHtml("<big><b><u>SAVING THROW MODIFIERS</u></b></big><br>" +
						    "Fortitude: " + pc.fortitude + "<br>" +
						    "Will: " + pc.will + "<br>" +
						    "Reflex: " + pc.reflex + "<br><br>" +
						    "<big><b><u>RESISTANCES (%)</u></b></big><br>" +
						    "Acid: " + pc.damageTypeResistanceTotalAcid + "<br>" +
						    "Cold: " + pc.damageTypeResistanceTotalCold + "<br>" +
						    "Normal: " + pc.damageTypeResistanceTotalNormal + "<br>" +
						    "Electricity: " + pc.damageTypeResistanceTotalElectricity + "<br>" +
						    "Fire: " + pc.damageTypeResistanceTotalFire + "<br>" +
						    "Magic: " + pc.damageTypeResistanceTotalMagic + "<br>" +
						    "Poison: " + pc.damageTypeResistanceTotalPoison + "<br>"
						    );
			    }
			    else if (btnMainHand.getImpact(x, y))
			    {
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    if (gv.cc.partyItemSlotIndex == 0)
				    {
					    switchEquipment(inCombat);
				    }
				    gv.cc.partyItemSlotIndex = 0;
			    }
			    else if (btnHead.getImpact(x, y))
			    {
				    if (inCombat) 
				    { 
					    gv.sf.MessageBoxHtml("Can't equip/unequip this item in combat.");
					    return;
				    }
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    if (gv.cc.partyItemSlotIndex == 1)
				    {
					    switchEquipment(inCombat);
				    }
				    gv.cc.partyItemSlotIndex = 1;
			    }
			    else if (btnNeck.getImpact(x, y))
			    {
				    if (inCombat) 
				    { 
					    gv.sf.MessageBoxHtml("Can't equip/unequip this item in combat.");
					    return;
				    }
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    if (gv.cc.partyItemSlotIndex == 2)
				    {
					    switchEquipment(inCombat);
				    }
				    gv.cc.partyItemSlotIndex = 2;
			    }
			    else if (btnOffHand.getImpact(x, y))
			    {
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    if (gv.cc.partyItemSlotIndex == 3)
				    {
					    switchEquipment(inCombat);
				    }
				    gv.cc.partyItemSlotIndex = 3;
			    }
			    else if (btnRing.getImpact(x, y))
			    {
				    if (inCombat) 
				    { 
					    gv.sf.MessageBoxHtml("Can't equip/unequip this item in combat.");
					    return;
				    }
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    if (gv.cc.partyItemSlotIndex == 4)
				    {
					    switchEquipment(inCombat);
				    }
				    gv.cc.partyItemSlotIndex = 4;
			    }	
			    else if (btnBody.getImpact(x, y))
			    {
				    if (inCombat) 
				    { 
					    gv.sf.MessageBoxHtml("Can't equip/unequip this item in combat.");
					    return;
				    }
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    if (gv.cc.partyItemSlotIndex == 5)
				    {
					    switchEquipment(inCombat);
				    }
				    gv.cc.partyItemSlotIndex = 5;
			    }
			    else if (btnFeet.getImpact(x, y))
			    {
				    if (inCombat) 
				    { 
					    gv.sf.MessageBoxHtml("Can't equip/unequip this item in combat.");
					    return;
				    }
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    if (gv.cc.partyItemSlotIndex == 6)
				    {
					    switchEquipment(inCombat);
				    }
				    gv.cc.partyItemSlotIndex = 6;
			    }
			    else if (btnRing2.getImpact(x, y))
			    {
				    if (inCombat) 
				    { 
					    gv.sf.MessageBoxHtml("Can't equip/unequip this item in combat.");
					    return;
				    }
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    if (gv.cc.partyItemSlotIndex == 7)
				    {
					    switchEquipment(inCombat);
				    }
				    gv.cc.partyItemSlotIndex = 7;
			    }
			    else if (btnAmmo.getImpact(x, y))
			    {
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    if (gv.cc.partyItemSlotIndex == 8)
				    {
					    switchEquipment(inCombat);
				    }
				    gv.cc.partyItemSlotIndex = 8;
			    }
			
			    else if (btnLevelUp.getImpact(x, y))
			    {
				    if (inCombat) 
				    { 
					    gv.sf.MessageBoxHtml("Can't Level up during combat.");
					    return;
				    }
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    if (mod.playerList[gv.cc.partyScreenPcIndex].IsReadyToAdvanceLevel())
				    {
					    if (mod.playerList[gv.cc.partyScreenPcIndex].charStatus.Equals("Dead"))
					    {
						    //Toast.makeText(gv.gameContext, "Can't Level Up a Dead Character", Toast.LENGTH_SHORT).show();
					    }
					    else
					    {
						    doLevelUp();
					    }			    	
			        }
			    }
			    else if (btnHelp.getImpact(x, y))
			    {
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    tutorialMessageParty(true);
			    }
			    else if (btnInfo.getImpact(x, y))
			    {
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    Item it = new Item();
				    if (gv.cc.partyItemSlotIndex == 0) { it = mod.getItemByResRef(pc.MainHandRefs.resref);}
				    else if (gv.cc.partyItemSlotIndex == 1) { it = mod.getItemByResRef(pc.HeadRefs.resref);}
				    else if (gv.cc.partyItemSlotIndex == 2) { it = mod.getItemByResRef(pc.NeckRefs.resref);}
				    else if (gv.cc.partyItemSlotIndex == 3) { it = mod.getItemByResRef(pc.OffHandRefs.resref);}
				    else if (gv.cc.partyItemSlotIndex == 4) { it = mod.getItemByResRef(pc.RingRefs.resref);}
				    else if (gv.cc.partyItemSlotIndex == 5) { it = mod.getItemByResRef(pc.BodyRefs.resref);}
				    else if (gv.cc.partyItemSlotIndex == 6) { it = mod.getItemByResRef(pc.FeetRefs.resref);}
				    else if (gv.cc.partyItemSlotIndex == 7) { it = mod.getItemByResRef(pc.Ring2Refs.resref);}
				    else if (gv.cc.partyItemSlotIndex == 8) { it = mod.getItemByResRef(pc.AmmoRefs.resref);}
				    if (it != null)
				    {
					    gv.sf.ShowFullDescription(it);
				    }
			    }
			    else if (btnReturn.getImpact(x, y))
			    {
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    if (inCombat)
				    {
					    if (gv.screenCombat.canMove)
					    {
						    gv.screenCombat.currentCombatMode = "move";
					    }
					    else
					    {
						    gv.screenCombat.currentCombatMode = "attack";
					    }
					    gv.screenType = "combat";
				    }
				    else
				    {
					    gv.screenType = "main";	
				    }
			    }
                else if (btnPartyRoster.getImpact(x, y))
                {
                    if (!inCombat)
                    {
                        //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
                        //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
                        gv.screenType = "partyRoster";
                        //gv.TrackerSendScreenView("PartyRoster");
                        //gv.TrackerSendEventPartyRoster("Open");
                    }
                }
			    if (!inCombat) 
			    {
				    for (int j = 0; j < mod.playerList.Count; j++)
				    {
					    if (btnPartyIndex[j].getImpact(x, y))
					    {
						    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
						    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
						    mod.selectedPartyLeader = j;
						    gv.cc.addLogText("lime", mod.playerList[j].name + " is Party Leader");
						    if (gv.cc.partyScreenPcIndex == j)
						    {						
							    doInterPartyConvo(); //not used in The Raventhal
						    }
						    gv.cc.partyScreenPcIndex = j;
					    }
				    }
			    }
			    break;	
		    }
	    }
        public String isUseableBy(Item it)
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
        public void doInterPartyConvo()
        {
    	    if (gv.cc.partyScreenPcIndex == 0)
    	    {
    		    return;
    	    }
    	    if (gv.cc.partyScreenPcIndex >= mod.playerList.Count)
    	    {
    		    return;
    	    }
    	    Player pc = mod.playerList[gv.cc.partyScreenPcIndex];
    	    gv.cc.doConversationBasedOnTag(pc.name);    	
        }
        public bool canNotBeUnequipped()
        {
    	    Player pc = mod.playerList[gv.cc.partyScreenPcIndex];
    	    if      (gv.cc.partyItemSlotIndex == 0) { return pc.MainHandRefs.canNotBeUnequipped; }
		    else if (gv.cc.partyItemSlotIndex == 1) { return pc.HeadRefs.canNotBeUnequipped; }
		    else if (gv.cc.partyItemSlotIndex == 2) { return pc.NeckRefs.canNotBeUnequipped; }
		    else if (gv.cc.partyItemSlotIndex == 3) { return pc.OffHandRefs.canNotBeUnequipped; }
		    else if (gv.cc.partyItemSlotIndex == 4) { return pc.RingRefs.canNotBeUnequipped; }
		    else if (gv.cc.partyItemSlotIndex == 5) { return pc.BodyRefs.canNotBeUnequipped; }
		    else if (gv.cc.partyItemSlotIndex == 6) { return pc.FeetRefs.canNotBeUnequipped; }
		    else if (gv.cc.partyItemSlotIndex == 7) { return pc.Ring2Refs.canNotBeUnequipped; }
		    else if (gv.cc.partyItemSlotIndex == 8) { return pc.AmmoRefs.canNotBeUnequipped; }
    	    return false;
        }
        public void switchEquipment(bool inCombat)
        {
    	    Player pc = mod.playerList[gv.cc.partyScreenPcIndex];
    	    if (gv.cc.partyItemSlotIndex == 3)
    	    {
    		    if (mod.getItemByResRefForInfo(pc.MainHandRefs.resref).twoHanded)
    		    {
    			    gv.sf.MessageBoxHtml("Can't equip an item in off-hand while using a two-handed weapon. Unequip the two-handed weapon from the main-hand first.");
    			    return;
    		    }
    	    }
    	
    	    //check to see if ammo can be used by MainHand weapon
    	    if (gv.cc.partyItemSlotIndex == 8)
    	    {
    		    Item itMH = mod.getItemByResRef(pc.MainHandRefs.resref);
    		    if ((!itMH.category.Equals("Ranged")) || (itMH.ammoType.Equals("none")))
			    {    		
    			    gv.sf.MessageBoxHtml("Can't use ammo with the weapon currently equipped in your main-hand.");
    			    return;
    		    }
    	    }
    	
    	    //check to see if item can not be unequipped
    	    if (canNotBeUnequipped())
		    {
			    gv.sf.MessageBoxHtml("Can't unequip this item...PC specific item or a cursed item.");
			    return;
		    }    	
    	
    	    //if (dialogOpen)
    	    //{
    		//    return;
    	    //}
    	    //dialogOpen = true;
    	
    	    List<ItemRefs> allowedItems = new List<ItemRefs>();

            //add the currently equipped item to the allowed list
            /*if (gv.cc.partyItemSlotIndex == 0) //Main Hand
            {
                allowedItems.Add(pc.MainHandRefs);
            }
            else if (gv.cc.partyItemSlotIndex == 1) //Head
            {
                allowedItems.Add(pc.HeadRefs);
            }
            else if (gv.cc.partyItemSlotIndex == 2) //Neck
            {
                allowedItems.Add(pc.NeckRefs);
            }
            else if (gv.cc.partyItemSlotIndex == 3) //Off Hand
            {
                allowedItems.Add(pc.OffHandRefs);
            }
            else if (gv.cc.partyItemSlotIndex == 4) //Ring
            {
                allowedItems.Add(pc.RingRefs);
            }
            else if (gv.cc.partyItemSlotIndex == 5) //Body
            {
                allowedItems.Add(pc.BodyRefs);
            }
            else if (gv.cc.partyItemSlotIndex == 6) //Feet
            {
                allowedItems.Add(pc.FeetRefs);
            }
            else if (gv.cc.partyItemSlotIndex == 7) //Ring2
            {
                allowedItems.Add(pc.Ring2Refs);
            }
            else if (gv.cc.partyItemSlotIndex == 8) //Ammo
            {
                allowedItems.Add(pc.AmmoRefs);
            }*/

            //add any other allowed items to the allowed list
            foreach (ItemRefs itRef in mod.partyInventoryRefsList)
            {
        	    Item it = mod.getItemByResRef(itRef.resref);
        	    if (gv.cc.partyItemSlotIndex == 0)
        	    {
        		    if ((it.category.Equals("Melee")) || (it.category.Equals("Ranged")))
        		    {        			
            		    if (pc.playerClass.containsItemRefsWithResRef(itRef.resref))
            		    {
            			    allowedItems.Add(itRef);
            		    }
        		    }
        	    }
        	    else if ((it.category.Equals("Head")) && (gv.cc.partyItemSlotIndex == 1))
        	    {
        		    if (pc.playerClass.containsItemRefsWithResRef(itRef.resref))
        		    {
        			    allowedItems.Add(itRef);
        		    }
        	    }
        	    else if ((it.category.Equals("Neck")) && (gv.cc.partyItemSlotIndex == 2))
        	    {
        		    if (pc.playerClass.containsItemRefsWithResRef(itRef.resref))
        		    {
        			    allowedItems.Add(itRef);
        		    }
        	    }
        	    else if ((it.category.Equals("Shield")) && (gv.cc.partyItemSlotIndex == 3))
        	    {
        		    if (pc.playerClass.containsItemRefsWithResRef(itRef.resref))
        		    {
        			    allowedItems.Add(itRef);
        		    }
        	    }
        	    else if ((it.category.Equals("Ring")) && (gv.cc.partyItemSlotIndex == 4))
        	    {
        		    if (pc.playerClass.containsItemRefsWithResRef(itRef.resref))
        		    {
        			    allowedItems.Add(itRef);
        		    }
        	    }
        	    else if ((it.category.Equals("Armor")) && (gv.cc.partyItemSlotIndex == 5))
        	    {
        		    if (pc.playerClass.containsItemRefsWithResRef(itRef.resref))
        		    {
        			    allowedItems.Add(itRef);
        		    }
        	    }
        	    else if ((it.category.Equals("Feet")) && (gv.cc.partyItemSlotIndex == 6))
        	    {
        		    if (pc.playerClass.containsItemRefsWithResRef(itRef.resref))
        		    {
        			    allowedItems.Add(itRef);
        		    }
        	    }
        	    else if ((it.category.Equals("Ring")) && (gv.cc.partyItemSlotIndex == 7))
        	    {
        		    if (pc.playerClass.containsItemRefsWithResRef(itRef.resref))
        		    {
        			    allowedItems.Add(itRef);
        		    }
        	    }
        	    else if ((it.category.Equals("Ammo")) && (gv.cc.partyItemSlotIndex == 8))
        	    {
        		    if (pc.playerClass.containsItemRefsWithResRef(itRef.resref))
        		    {
        			    Item itMH = mod.getItemByResRef(pc.MainHandRefs.resref);
        			    if ((itMH.category.Equals("Ranged")) && (!itMH.ammoType.Equals("none")) && (itMH.ammoType.Equals(it.ammoType)))
        			    {
        				    allowedItems.Add(itRef);
        			    }
        		    }
        	    }
            }

            //pass items to selector
            gv.screenType = "itemSelector";
            if (inCombat)
            {
                gv.screenItemSelector.resetItemSelector(allowedItems, "equip", "combatParty");
            }
            else
            {
                gv.screenItemSelector.resetItemSelector(allowedItems, "equip", "party");
            }

            /*List<string> listItems = new List<string>();
        
		    if (gv.cc.partyItemSlotIndex == 0) //Main Hand
		    {
			    listItems.Add("(equipped) " + pc.MainHandRefs.name);
		    }
		    else if (gv.cc.partyItemSlotIndex == 1) //Head
		    {
			    listItems.Add("(equipped) " + pc.HeadRefs.name);
		    }
		    else if (gv.cc.partyItemSlotIndex == 2) //Neck
		    {
			    listItems.Add("(equipped) " + pc.NeckRefs.name);
		    }
		    else if (gv.cc.partyItemSlotIndex == 3) //Off Hand
		    {
			    listItems.Add("(equipped) " + pc.OffHandRefs.name);
		    }
		    else if (gv.cc.partyItemSlotIndex == 4) //Ring
		    {
			    listItems.Add("(equipped) " + pc.RingRefs.name);
		    }
		    else if (gv.cc.partyItemSlotIndex == 5) //Body
		    {
			    listItems.Add("(equipped) " + pc.BodyRefs.name);
		    }
		    else if (gv.cc.partyItemSlotIndex == 6) //Feet
		    {
			    listItems.Add("(equipped) " + pc.FeetRefs.name);
		    }
		    else if (gv.cc.partyItemSlotIndex == 7) //Ring2
		    {
			    listItems.Add("(equipped) " + pc.Ring2Refs.name);
		    }
		    else if (gv.cc.partyItemSlotIndex == 8) //Ammo
		    {
			    listItems.Add("(equipped) " + pc.AmmoRefs.name);
		    }
            listItems.Add("none");
            foreach (ItemRefs i in allowedItems)
            {
        	    listItems.Add(i.name);
            }*/

            /*
            final CharSequence[] items = listItems.toArray(new CharSequence[listItems.size()]);
            // Creating and Building the Dialog 
            AlertDialog.Builder builder = new AlertDialog.Builder(gv.gameContext);
            builder.setTitle("Equip the following item");
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
            	    Player pc = mod.playerList.get(gv.cc.partyScreenPcIndex);
            	    if (item > 1)
            	    {
            		    if (gv.cc.partyItemSlotIndex == 0) //Main Hand
            		    {
            			    if (!pc.MainHandRefs.resref.equals("none"))
            			    {
            				    //move currently equipped item to the party inventory (list and taglist)
            				    mod.partyInventoryRefsList.add(pc.MainHandRefs.DeepCopy());
            				    //mod.partyInventoryTagList.add(mod.playerList.get(gv.cc.partyScreenPcIndex).MainHand.tag);
            				    //place the item into the main hand
            				    pc.MainHandRefs = allowedItems.get(item-2).DeepCopy();
            				    //mod.playerList.get(gv.cc.partyScreenPcIndex).MainHandTag = allowedItems.get(item-2).tag;
            				    //remove the item from the party inventory
            				    mod.partyInventoryRefsList.remove(allowedItems.get(item-2));
            				    //mod.partyInventoryTagList.remove(allowedItems.get(item-2).tag);
            			    }
            			    else //there was no item equipped so add item to main-hand but no need to move anything to party inventory
            			    {
            				    pc.MainHandRefs = allowedItems.get(item-2).DeepCopy();
            				    //mod.playerList.get(gv.cc.partyScreenPcIndex).MainHandTag = allowedItems.get(item-2).tag;
            				    mod.partyInventoryRefsList.remove(allowedItems.get(item-2));	                				
            				    //mod.partyInventoryTagList.remove(allowedItems.get(item-2).tag);
            			    }
            			    //if the item being equipped is a two-handed weapon, remove the item in off-hand if exists and place in inventory
            			    if (mod.getItemByResRef(pc.MainHandRefs.resref).twoHanded)
            			    {
            				    if (!pc.OffHandRefs.resref.equals("none"))
                			    {
                				    mod.partyInventoryRefsList.add(pc.OffHandRefs.DeepCopy());
                				    //mod.partyInventoryTagList.add(mod.playerList.get(gv.cc.partyScreenPcIndex).OffHand.tag);
                				    pc.OffHandRefs = new ItemRefs();	                				
                				    //mod.playerList.get(gv.cc.partyScreenPcIndex).OffHandTag = "none";
                				
                				    gv.sf.MessageBoxHtml("Equipping a two-handed weapon, removing item from off-hand and placing it in the party's inventory.");
                			    }
            			    }
            			    //if the item is a ranged weapon that uses ammo, check ammo slot to see if need to remove ammo not this type
            			    Item itMH = mod.getItemByResRef(pc.MainHandRefs.resref);
            			    Item itA = mod.getItemByResRef(pc.AmmoRefs.resref);
            			    if ((itA != null) && (itMH != null))
            			    {
	            			    if ((itMH.category.equals("Ranged")) && (!itMH.ammoType.equals("none")) && (itMH.ammoType.equals(itA.ammoType)))
	            			    {
	            				    //compatible ammo so leave as is
	            			    }
	            			    else //ammo not compatible so remove ItemRefs
	            			    {
	            				    pc.AmmoRefs = new ItemRefs();	                				
	            				    gv.sf.MessageBoxHtml("Currently assigned ammo is not compatible with this weapon, unassigning ammo.");
	            			    }
            			    }
            		    }
            		    else if (gv.cc.partyItemSlotIndex == 1) //Head
            		    {
            			    // if equip slot has an item, move it to inventory first
            			    if (!pc.HeadRefs.resref.equals("none"))
            			    {
            				    mod.partyInventoryRefsList.add(pc.HeadRefs.DeepCopy());
            				    pc.HeadRefs = allowedItems.get(item-2).DeepCopy();
            				    mod.partyInventoryRefsList.remove(allowedItems.get(item-2));
            			    }
            			    else //equip slot was empty
            			    {
            				    pc.HeadRefs = allowedItems.get(item-2).DeepCopy();
            				    mod.partyInventoryRefsList.remove(allowedItems.get(item-2));
            			    }
            		    }
            		    else if (gv.cc.partyItemSlotIndex == 2) //Neck
            		    {
            			    // if equip slot has an item, move it to inventory first
            			    if (!pc.NeckRefs.resref.equals("none"))
            			    {
            				    mod.partyInventoryRefsList.add(pc.NeckRefs.DeepCopy());
            				    pc.NeckRefs = allowedItems.get(item-2).DeepCopy();
            				    mod.partyInventoryRefsList.remove(allowedItems.get(item-2));
            			    }
            			    else //equip slot was empty
            			    {
            				    pc.NeckRefs = allowedItems.get(item-2).DeepCopy();
            				    mod.partyInventoryRefsList.remove(allowedItems.get(item-2));
            			    }
            		    }
            		    else if (gv.cc.partyItemSlotIndex == 3) //Off Hand
            		    {
            			    if (!pc.OffHandRefs.resref.equals("none"))
            			    {
            				    mod.partyInventoryRefsList.add(pc.OffHandRefs.DeepCopy());
            				    pc.OffHandRefs = allowedItems.get(item-2).DeepCopy();
            				    mod.partyInventoryRefsList.remove(allowedItems.get(item-2));
            			    }
            			    else
            			    {
            				    pc.OffHandRefs = allowedItems.get(item-2).DeepCopy();
            				    mod.partyInventoryRefsList.remove(allowedItems.get(item-2));
            			    }
            		    }
            		    else if (gv.cc.partyItemSlotIndex == 4)//Ring
            		    {
            			    if (!pc.RingRefs.resref.equals("none"))
            			    {
            				    mod.partyInventoryRefsList.add(pc.RingRefs.DeepCopy());
            				    pc.RingRefs = allowedItems.get(item-2).DeepCopy();
            				    mod.partyInventoryRefsList.remove(allowedItems.get(item-2));
            			    }
            			    else
            			    {
            				    pc.RingRefs = allowedItems.get(item-2).DeepCopy();
            				    mod.partyInventoryRefsList.remove(allowedItems.get(item-2));
            			    }
            		    }
            		    else if (gv.cc.partyItemSlotIndex == 5) //Body
            		    {
            			    // if equip slot has an item, move it to inventory first
            			    if (!pc.BodyRefs.resref.equals("none"))
            			    {
            				    mod.partyInventoryRefsList.add(pc.BodyRefs.DeepCopy());
            				    pc.BodyRefs = allowedItems.get(item-2).DeepCopy();
            				    mod.partyInventoryRefsList.remove(allowedItems.get(item-2));
            			    }
            			    else //equip slot was empty
            			    {
            				    pc.BodyRefs = allowedItems.get(item-2).DeepCopy();
            				    mod.partyInventoryRefsList.remove(allowedItems.get(item-2));
            			    }
            		    }
            		    else if (gv.cc.partyItemSlotIndex == 6) //Feet
            		    {
            			    // if equip slot has an item, move it to inventory first
            			    if (!pc.FeetRefs.resref.equals("none"))
            			    {
            				    mod.partyInventoryRefsList.add(pc.FeetRefs.DeepCopy());
            				    pc.FeetRefs = allowedItems.get(item-2).DeepCopy();
            				    mod.partyInventoryRefsList.remove(allowedItems.get(item-2));
            			    }
            			    else //equip slot was empty
            			    {
            				    pc.FeetRefs = allowedItems.get(item-2).DeepCopy();
            				    mod.partyInventoryRefsList.remove(allowedItems.get(item-2));
            			    }
            		    }
            		    else if (gv.cc.partyItemSlotIndex == 7) //Ring2
            		    {
            			    if (!pc.Ring2Refs.resref.equals("none"))
            			    {
            				    mod.partyInventoryRefsList.add(pc.Ring2Refs.DeepCopy());
            				    pc.Ring2Refs = allowedItems.get(item-2).DeepCopy();
            				    mod.partyInventoryRefsList.remove(allowedItems.get(item-2));
            			    }
            			    else
            			    {
            				    pc.Ring2Refs = allowedItems.get(item-2).DeepCopy();
            				    mod.partyInventoryRefsList.remove(allowedItems.get(item-2));
            			    }
            		    }
            		    else if (gv.cc.partyItemSlotIndex == 8) //Ammo
            		    {
            			    // if equip slot has an ammo, no need to move it to inventory since it is only a ref            			
        				    pc.AmmoRefs = allowedItems.get(item-2).DeepCopy();
            		    }
            	    }
            	    else if (item == 1) //selected "none"
            	    {
            		    if (gv.cc.partyItemSlotIndex == 0) //Main Hand
            		    {
            			    // if equip slot has an item, move it to inventory            		
                		    if (!pc.MainHandRefs.resref.equals("none"))
            			    {
            				    mod.partyInventoryRefsList.add(pc.MainHandRefs.DeepCopy());
            				    pc.MainHandRefs = new ItemRefs();
            			    }
            		    }
            		    else if (gv.cc.partyItemSlotIndex == 1) //Head
            		    {
            			    // if equip slot has an item, move it to inventory first
            			    if (!pc.HeadRefs.resref.equals("none"))
            			    {
            				    mod.partyInventoryRefsList.add(pc.HeadRefs.DeepCopy());
            				    pc.HeadRefs = new ItemRefs();
            			    }	                			
            		    }
            		    else if (gv.cc.partyItemSlotIndex == 2) //Neck
            		    {
            			    // if equip slot has an item, move it to inventory first
            			    if (!pc.NeckRefs.resref.equals("none"))
            			    {
            				    mod.partyInventoryRefsList.add(pc.NeckRefs.DeepCopy());
            				    pc.NeckRefs = new ItemRefs();
            			    }	                			
            		    }
            		    else if (gv.cc.partyItemSlotIndex == 3) //Off Hand
            		    {
            			    if (!pc.OffHandRefs.resref.equals("none"))
            			    {
            				    mod.partyInventoryRefsList.add(pc.OffHandRefs.DeepCopy());
            				    pc.OffHandRefs = new ItemRefs();
            			    }	                			
            		    }
            		    else if (gv.cc.partyItemSlotIndex == 4) //Ring
            		    {
            			    if (!pc.RingRefs.resref.equals("none"))
            			    {
            				    mod.partyInventoryRefsList.add(pc.RingRefs.DeepCopy());
            				    pc.RingRefs = new ItemRefs();
            			    }	                			
            		    }	 
            		    else if (gv.cc.partyItemSlotIndex == 5) //Body
            		    {
            			    // if equip slot has an item, move it to inventory first
            			    if (!pc.BodyRefs.resref.equals("none"))
            			    {
            				    mod.partyInventoryRefsList.add(pc.BodyRefs.DeepCopy());
            				    pc.BodyRefs = new ItemRefs();
            			    }	                			
            		    }
            		    else if (gv.cc.partyItemSlotIndex == 6) //Feet
            		    {
            			    // if equip slot has an item, move it to inventory first
            			    if (!pc.FeetRefs.resref.equals("none"))
            			    {
            				    mod.partyInventoryRefsList.add(pc.FeetRefs.DeepCopy());
            				    pc.FeetRefs = new ItemRefs();
            			    }	                			
            		    }
            		    else if (gv.cc.partyItemSlotIndex == 7) //Ring2
            		    {
            			    if (!pc.Ring2Refs.resref.equals("none"))
            			    {
            				    mod.partyInventoryRefsList.add(pc.Ring2Refs.DeepCopy());
            				    pc.Ring2Refs = new ItemRefs();
            			    }	                			
            		    }
            		    else if (gv.cc.partyItemSlotIndex == 8) //Ammo
            		    {
            			    // if equip slot has an item, move it to inventory first
            			    pc.AmmoRefs = new ItemRefs();            			                			
            		    }
            	    }
            	    dialogOpen = false;
            	    gv.ItemDialog.dismiss();
            	    gv.invalidate();
                }
            });
            gv.ItemDialog = builder.create();
            gv.ItemDialog.show();
            */
        }
        public void doLevelUp()
        {
    	    Player pc = mod.playerList[gv.cc.partyScreenPcIndex];
            /*
    	    AlertDialog.Builder builder = new AlertDialog.Builder(gv.gameContext);
    	    builder.setMessage(pc.name + " has gained enough experience to advance a level!")
    	           .setCancelable(false)
    	           .setPositiveButton("LEVEL UP", new DialogInterface.OnClickListener() 
    	           {
    	               public void onClick(DialogInterface dialog, int id) 
    	               {    	 
					       Player pc = mod.playerList.get(gv.cc.partyScreenPcIndex);    	        	   
					       //LEVEL UP ALL STATS AND UPDATE STATS
					       pc.LevelUp();
					       gv.sf.UpdateStats(pc);
					       traitGained = "Trait Gained: ";
					       spellGained = "Spell Gained: ";
					   
					       //if automatically learned traits or spells add them
					       for (TraitAllowed ta : pc.playerClass.traitsAllowed)
					       {
						       if ((ta.automaticallyLearned) && (ta.atWhatLevelIsAvailable == pc.classLevel))
						       {
							       traitGained += ta.name + ", ";
							       pc.knownTraitsTags.add(ta.tag);
						       }
					       }
					       for (SpellAllowed sa : pc.playerClass.spellsAllowed)
					       {
						       if ((sa.automaticallyLearned) && (sa.atWhatLevelIsAvailable == pc.classLevel))
						       {
							       spellGained += sa.name + ", ";
							       pc.knownSpellsTags.add(sa.tag);
						       }
					       }
    				   
					       //check to see if have any traits to learn
					       List<String> traitTagsList = new ArrayList<String>();
					       traitTagsList = pc.getTraitsToLearn(gv.mod);
						
					       //check to see if have any spells to learn
					       List<String> spellTagsList = new ArrayList<String>();
					       spellTagsList = pc.getSpellsToLearn();
	   			    
    	        	       //if so then ask which one
    	        	       if (traitTagsList.size() > 0)
    	        	       {
    	        		       gv.screenTraitLevelUp.resetPC(pc);
    	        		       gv.screenType = "learnTraitLevelUp";
    	        		       gv.invalidate();
    	        	       }
    	        	       else if (spellTagsList.size() > 0)
    	        	       {
    	        		       gv.screenSpellLevelUp.resetPC(pc);
    	        		       gv.screenType = "learnSpellLevelUp";
    	        		       gv.invalidate();
    	        	       }
    	        	       else //no spells or traits to learn
    	        	       {
    	        		       doLevelUpSummary();
    	        	       }
    	               }
    	           });
    	    AlertDialog alert = builder.create();
    	    alert.show();
            */
        }
        public void doLevelUpSummary()
        {
    	    Player pc = mod.playerList[gv.cc.partyScreenPcIndex];
    	    int babGained = pc.playerClass.babTable[pc.classLevel] - pc.playerClass.babTable[pc.classLevel - 1];
    	
    	    //gv.TrackerSendEventOnePlayerInfo(pc,"LevelUp:"+pc.name);

            /*
    	    // Creating and Building the Dialog 
 	   	    AlertDialog.Builder builder = new AlertDialog.Builder(gv.gameContext);
            builder.setTitle("Level Up Summary");
            builder.setMessage(pc.name + " has gained:\n"
     		       + "HP: +" + pc.playerClass.hpPerLevelUp + "\n"
     		       + "SP: +" + pc.playerClass.spPerLevelUp + "\n"
     		       + "BAB: +" + babGained + "\n"
     		       + traitGained + "\n"
     		       + spellGained);
	        builder.setCancelable(false);
            builder.setPositiveButton("Done", new DialogInterface.OnClickListener() 
		           {
		               public void onClick(DialogInterface dialog, int id) 
		               {    	 
		        	       //close dialog
		        	       gv.invalidate();
		               }
		           });
            AlertDialog alert = builder.create();
    	    alert.show();
            */
        }
        public void tutorialMessageParty(bool helpCall)
        {
    	    if ((mod.showTutorialParty) || (helpCall))
		    {
    		    gv.sf.MessageBoxHtml(gv.cc.stringMessageParty);
			    mod.showTutorialParty = false;
		    }
        }
    }
}
