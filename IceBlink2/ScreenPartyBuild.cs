﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IceBlink2
{
    public class ScreenPartyBuild 
    {
	    public Module mod;
	    public GameView gv;

	    public List<IbbButton> btnPartyIndex = new List<IbbButton>();
	    public List<Player> pcList = new List<Player>();
	    private IbbButton btnLeft = null;
	    private IbbButton btnRight = null;
	    private IbbButton btnPcListIndex = null;
	    private IbbButton btnAdd = null;
	    private IbbButton btnRemove = null;
	    private IbbButton btnCreate = null;
	    private IbbButton btnHelp = null;
	    private IbbButton btnReturn = null;
	    private bool dialogOpen = false;
	    private int partyScreenPcIndex = 0;
	    private int pcIndex = 0;
	    private bool lastClickedPlayerList = true;
	    private string stringMessagePartyBuild = "";
	
	    public ScreenPartyBuild(Module m, GameView g)
	    {
		    mod = m;
		    gv = g;
		    setControlsStart();
		    stringMessagePartyBuild = gv.cc.loadTextToString("data/MessagePartyBuild.txt");
		    //create a list of character .json files from saves/modulefoldername/characters and the default PC
		    loadPlayerList();
	    }    
	    public void refreshPlayerTokens()
	    {
		    int cntPCs = 0;
		    foreach (IbbButton btn in btnPartyIndex)
		    {
			    if (cntPCs < mod.playerList.Count)
			    {
				    btn.Img2 = gv.cc.LoadBitmap(mod.playerList[cntPCs].tokenFilename);						
			    }
			    else
			    {
				    btn.Img2 = null;
			    }
			    cntPCs++;
		    }
	    }	
	    public void loadPlayerList()
	    {
            pcList.Clear();
            string[] files;
            if (Directory.Exists(gv.mainDirectory + "\\saves\\" + gv.mod.moduleName + "\\characters"))
            {
                files = Directory.GetFiles(gv.mainDirectory + "\\saves\\" + gv.mod.moduleName + "\\characters", "*.json");
                //directory.mkdirs(); 
                foreach (string file in files)
                {
                    try
                    {
                        //string filename = Path.GetFileName(file); //drin.json
                        AddCharacterToList(file);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
	    }
	    public void AddCharacterToList(string filename)
        {
    	    try
            {
                Player newPc = LoadPlayer(filename); //ex: filename = "ezzbel.json"
                newPc.token = gv.cc.LoadBitmap(newPc.tokenFilename);
    		    newPc.playerClass = mod.getPlayerClass(newPc.classTag);
    		    newPc.race = mod.getRace(newPc.raceTag);
    		    //check to see if already in party before adding
                bool foundOne = false;
                foreach (Player pc in pcList)
                {
                    if (newPc.tag.Equals(pc.tag))
                    {
                        foundOne = true;
                    }
                }
                if (!foundOne)
                {
            	    pcList.Add(newPc);            	
                }
                else
                {
            	    //MessageBox.Show("This PC is already in the party");
                }
            }
            catch (Exception ex)
            {
        	    MessageBox.Show("failed to load character from character folder: " + ex.ToString());    		         
            }             
        }
	    public Player LoadPlayer(string filename)
	    {	            
		    Player toReturn = null;
            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                toReturn = (Player)serializer.Deserialize(file, typeof(Player));
            }
            return toReturn;           
	    }
    
	    public void setControlsStart()
	    {		
    	    int pW = (int)((float)gv.screenWidth / 100.0f);
		    int pH = (int)((float)gv.screenHeight / 100.0f);
            int center = gv.screenWidth / 2;
		    int padW = gv.squareSize/6;
		
		    for (int x = 0; x < mod.numberOfPlayerMadePcsAllowed; x++)
		    {
			    IbbButton btnNew = new IbbButton(gv, 1.0f);	
			    btnNew.Img = gv.cc.LoadBitmap("item_slot"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.item_slot);
			    btnNew.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnNew.X = ((x+5) * gv.squareSize) + (padW * (x + 1)) + gv.oXshift;
			    btnNew.Y = (gv.squareSize / 2) + (pH * 2);
                btnNew.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnNew.Width = (int)(gv.ibbwidthR * gv.screenDensity);	
			
			    btnPartyIndex.Add(btnNew);
		    }
		
		    if (btnAdd == null)
		    {
			    btnAdd = new IbbButton(gv, 1.0f);	
			    btnAdd.Img = gv.cc.LoadBitmap("btn_large"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_large);
			    btnAdd.Glow = gv.cc.LoadBitmap("btn_large_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_large_glow);
			    btnAdd.Text = "Add Character";
                btnAdd.X = center - (int)(gv.ibbwidthL * gv.screenDensity) - pW * 1;
			    btnAdd.Y = 2 * gv.squareSize + pH;
                btnAdd.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnAdd.Width = (int)(gv.ibbwidthL * gv.screenDensity);
		    }
		    if (btnRemove == null)
		    {
			    btnRemove = new IbbButton(gv, 1.0f);	
			    btnRemove.Img = gv.cc.LoadBitmap("btn_large"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_large);
			    btnRemove.Glow = gv.cc.LoadBitmap("btn_large_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_large_glow);
			    btnRemove.Text = "Remove Character";
                btnRemove.X = center + pW * 1;
			    btnRemove.Y = 2 * gv.squareSize + pH;
                btnRemove.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnRemove.Width = (int)(gv.ibbwidthL * gv.screenDensity);
		    }
		
		    if (btnLeft == null)
		    {
			    btnLeft = new IbbButton(gv, 1.0f);
			    btnLeft.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small);
			    btnLeft.Img2 = gv.cc.LoadBitmap("ctrl_left_arrow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.ctrl_left_arrow);
			    btnLeft.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnLeft.X = center - gv.squareSize * 2;
			    btnLeft.Y = (3 * gv.squareSize) + (pH * 2);
                btnLeft.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnLeft.Width = (int)(gv.ibbwidthR * gv.screenDensity);
		    }
		    if (btnPcListIndex == null)
		    {
			    btnPcListIndex = new IbbButton(gv, 1.0f);
			    btnPcListIndex.Img = gv.cc.LoadBitmap("item_slot"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_off);
			    btnPcListIndex.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnPcListIndex.Text = "";
			    btnPcListIndex.X = center - gv.squareSize/2;
			    btnPcListIndex.Y = (3 * gv.squareSize) + (pH * 2);
                btnPcListIndex.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnPcListIndex.Width = (int)(gv.ibbwidthR * gv.screenDensity);
		    }
		    if (btnRight == null)
		    {
			    btnRight = new IbbButton(gv, 1.0f);
			    btnRight.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small);
			    btnRight.Img2 = gv.cc.LoadBitmap("ctrl_right_arrow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.ctrl_right_arrow);
			    btnRight.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnRight.X = center + gv.squareSize * 1;
			    btnRight.Y = (3 * gv.squareSize) + (pH * 2);
                btnRight.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnRight.Width = (int)(gv.ibbwidthR * gv.screenDensity);
		    }
		    if (btnCreate == null)
		    {
			    btnCreate = new IbbButton(gv, 1.0f);	
			    btnCreate.Text = "CREATE CHARACTER";
			    btnCreate.Img = gv.cc.LoadBitmap("btn_large"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_large);
			    btnCreate.Glow = gv.cc.LoadBitmap("btn_large_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_large_glow);
                btnCreate.X = center - (int)((gv.ibbwidthL / 2) * gv.screenDensity);
			    btnCreate.Y = 4 * gv.squareSize + (pH * 3);
                btnCreate.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnCreate.Width = (int)(gv.ibbwidthL * gv.screenDensity);			
		    }
		
		    if (btnHelp == null)
		    {
			    btnHelp = new IbbButton(gv, 0.8f);	
			    btnHelp.Text = "HELP";
			    btnHelp.Img = gv.cc.LoadBitmap("btn_small"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small);
			    btnHelp.Glow = gv.cc.LoadBitmap("btn_small_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_small_glow);
			    btnHelp.X = 2 * gv.squareSize + padW * 1 + gv.oXshift;
			    //btnHelp.X = pW * 2;
			    btnHelp.Y = 9 * gv.squareSize + (pH * 2);
                btnHelp.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnHelp.Width = (int)(gv.ibbwidthR * gv.screenDensity);			
		    }
		    if (btnReturn == null)
		    {
			    btnReturn = new IbbButton(gv, 1.0f);	
			    btnReturn.Text = "START GAME";
			    btnReturn.Img = gv.cc.LoadBitmap("btn_large"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_large);
			    btnReturn.Glow = gv.cc.LoadBitmap("btn_large_glow"); // BitmapFactory.decodeResource(gv.getResources(), R.drawable.btn_large_glow);
                btnReturn.X = center - (int)((gv.ibbwidthL / 2) * gv.screenDensity);
			    btnReturn.Y = 9 * gv.squareSize + (pH * 2);
                btnReturn.Height = (int)(gv.ibbheight * gv.screenDensity);
                btnReturn.Width = (int)(gv.ibbwidthL * gv.screenDensity);			
		    }
	    }
	
	    //PARTY SCREEN
        public void redrawPartyBuild()
        {    	
    	    if (partyScreenPcIndex >= mod.playerList.Count)
    	    {
    		    partyScreenPcIndex = 0;
    	    }
    	    if (pcIndex >= pcList.Count)
    	    {
    		    pcIndex = 0;
    	    }
    	    Player pc = null;
    	    if ((mod.playerList.Count > 0) && (lastClickedPlayerList))
    	    {
    		    pc = mod.playerList[partyScreenPcIndex];
    	    }
    	    else if ((pcList.Count > 0) && (!lastClickedPlayerList))
    	    {
    		    pc = pcList[pcIndex];    		
    	    }
    	    if (pc != null)
    	    {
    		    gv.sf.UpdateStats(pc);
    	    }
            
    	    int pW = (int)((float)gv.screenWidth / 100.0f);
		    int pH = (int)((float)gv.screenHeight / 100.0f);
		    int padH = gv.squareSize/6;
    	    int locY = 0;
            int locX = 2 * gv.squareSize + gv.oXshift;
    	    //int spacing = (int)gv.mSheetTextPaint.getTextSize() + pH;
            int spacing = (int)gv.cc.MeasureString("GetHeight", gv.drawFontReg, gv.Width).Height;
    	    int tabX = pW * 50;
    	    int tabX2 = pW * 60;
    	    int leftStartY = 5 * gv.squareSize + (pH * 6);
    	    //int rightStartY = pH * 40;
		
		    //canvas.drawColor(Color.DKGRAY);
		
		    //Draw screen title name
		    string text = "Party Members [" + mod.numberOfPlayerMadePcsAllowed + " player made PC(s) Allowed]";
            // Measure string.
            SizeF stringSize = gv.cc.MeasureString(text, gv.drawFontReg, gv.Width);
            //Rect bounds = new Rect();
		    //gv.mSheetTextPaint.getTextBounds(text, 0, text.length(), bounds);
		    int ulX = (gv.screenWidth / 2) - ((int)stringSize.Width / 2);
		    //gv.mSheetTextPaint.setColor(Color.LTGRAY);
            gv.DrawText(text, ulX, pH * 3, 1.0f, Color.White);
		    //canvas.drawText(text, ulX, pH * 3, gv.mSheetTextPaint);
		
		    //DRAW EACH PC BUTTON
		    this.refreshPlayerTokens();
		
		    int cntPCs = 0;
		    foreach (IbbButton btn in btnPartyIndex)
		    {
			    if (cntPCs < mod.playerList.Count)
			    {
				    if (cntPCs == partyScreenPcIndex) {btn.glowOn = true;}
				    else {btn.glowOn = false;}					
				    btn.Draw();
			    }
			    cntPCs++;
		    }
		
		    btnLeft.Draw();
		    btnRight.Draw();	    
		    btnAdd.Draw();
		    btnRemove.Draw();
		    btnCreate.Draw();
		    btnHelp.Draw();
		    btnReturn.Draw();
				
		    if (pcList.Count > 0)
		    {
			    btnPcListIndex.Img2 = gv.cc.LoadBitmap(pcList[pcIndex].tokenFilename);						
		    }
		    else
		    {
			    btnPcListIndex.Img2 = null;
		    }
		    btnPcListIndex.Draw();
		
		    if (pc != null)
		    {
                
			    //DRAW LEFT STATS
			    //gv.mSheetTextPaint.setColor(Color.WHITE);
			    //canvas.drawText("Name: " + pc.name, locX, locY += leftStartY, gv.mSheetTextPaint);
                gv.DrawText("Name: " + pc.name, locX, locY += leftStartY);
			    //gv.mSheetTextPaint.setColor(Color.WHITE);
			    //canvas.drawText("Race: " + mod.getRace(pc.raceTag).name, locX, locY += spacing, gv.mSheetTextPaint);
                gv.DrawText("Race: " + mod.getRace(pc.raceTag).name, locX, locY += spacing);
			    if (pc.isMale)
			    {
				    //canvas.drawText("Gender: Male", locX, locY += spacing, gv.mSheetTextPaint);
                    gv.DrawText("Gender: Male", locX, locY += spacing);
			    }
			    else
			    {
				    //canvas.drawText("Gender: Female", locX, locY += spacing, gv.mSheetTextPaint);
                    gv.DrawText("Gender: Female", locX, locY += spacing);
			    }
			    //canvas.drawText("Class: " + mod.getPlayerClass(pc.classTag).name, locX, locY += spacing, gv.mSheetTextPaint);
                gv.DrawText("Class: " + mod.getPlayerClass(pc.classTag).name, locX, locY += spacing);
			    //canvas.drawText("Level: " + pc.classLevel, locX, locY += spacing, gv.mSheetTextPaint);
                gv.DrawText("Level: " + pc.classLevel, locX, locY += spacing);
			    //canvas.drawText("XP: " + pc.XP + "/" + pc.XPNeeded, locX, locY += spacing, gv.mSheetTextPaint);
                gv.DrawText("XP: " + pc.XP + "/" + pc.XPNeeded, locX, locY += spacing);
			    //canvas.drawText("---------------", locX, locY += spacing, gv.mSheetTextPaint);
                gv.DrawText("---------------", locX, locY += spacing);
			
			    //draw spells known list
			    string allSpells = "";
			    foreach (string s in pc.knownSpellsTags)
			    {
				    Spell sp = mod.getSpellByTag(s);
				    allSpells += sp.name + ", ";
			    }
			    //TODOcanvas.drawText("Spells: " + allSpells, locX, locY += spacing, gv.mSheetTextPaint);
                gv.DrawText("Spells: " + allSpells, locX, locY += spacing);
			
			    //draw traits known list
			    string allTraits = "";
			    foreach (string s in pc.knownTraitsTags)
			    {
				    Trait tr = mod.getTraitByTag(s);
				    allTraits += tr.name + ", ";
			    }
			    //TODOcanvas.drawText("Traits: " + allTraits, locX, locY += spacing, gv.mSheetTextPaint);
                gv.DrawText("Traits: " + allTraits, locX, locY += spacing);
                
			    //DRAW RIGHT STATS
			    locY = 0;
			    //canvas.drawText("STR: " + pc.strength, tabX, locY += leftStartY, gv.mSheetTextPaint);
                gv.DrawText("STR: " + pc.strength, tabX, locY += leftStartY);
			    //canvas.drawText("AC: " + pc.AC, tabX2, locY, gv.mSheetTextPaint);
                gv.DrawText("AC: " + pc.AC, tabX2, locY);
			    //canvas.drawText("DEX: " + pc.dexterity, tabX, locY += spacing, gv.mSheetTextPaint);
                gv.DrawText("DEX: " + pc.dexterity, tabX, locY += spacing);
			    //canvas.drawText("HP: " + pc.hp + "/" + pc.hpMax, tabX2, locY, gv.mSheetTextPaint);
                gv.DrawText("HP: " + pc.hp + "/" + pc.hpMax, tabX2, locY);
			    //canvas.drawText("INT: " + pc.intelligence, tabX, locY += spacing, gv.mSheetTextPaint);
                gv.DrawText("INT: " + pc.intelligence, tabX, locY += spacing);
			    //canvas.drawText("SP: " + pc.sp + "/" + pc.spMax, tabX2, locY, gv.mSheetTextPaint);
                gv.DrawText("SP: " + pc.sp + "/" + pc.spMax, tabX2, locY);
			    //canvas.drawText("CHA: " + pc.charisma, tabX, locY += spacing, gv.mSheetTextPaint);
                gv.DrawText("CHA: " + pc.charisma, tabX, locY += spacing);
			    //canvas.drawText("BAB: " + pc.baseAttBonus, tabX2, locY, gv.mSheetTextPaint);
                gv.DrawText("BAB: " + pc.baseAttBonus, tabX2, locY);
                
		    }            
       }
        public void onTouchPartyBuild(MouseEventArgs e, MouseEventType.EventType eventType)
	    {
		    btnAdd.glowOn = false;
		    btnRemove.glowOn = false;
		    btnLeft.glowOn = false;
		    btnRight.glowOn = false;
		    btnCreate.glowOn = false;
		    btnHelp.glowOn = false;		
		    btnReturn.glowOn = false;
		
		    //int eventAction = event.getAction();
		    switch (eventType)
		    {
		    case MouseEventType.EventType.MouseDown:
		    case MouseEventType.EventType.MouseMove:
			    int x = (int) e.X;
			    int y = (int) e.Y;

			    if (btnAdd.getImpact(x, y))
			    {
				    btnAdd.glowOn = true;
			    }
			    else if (btnRemove.getImpact(x, y))
			    {
				    btnRemove.glowOn = true;
			    }
			    else if (btnLeft.getImpact(x, y))
			    {
				    btnLeft.glowOn = true;
			    }
			    else if (btnPcListIndex.getImpact(x, y))
			    {
				    btnPcListIndex.glowOn = true;
			    }
			    else if (btnRight.getImpact(x, y))
			    {
				    btnRight.glowOn = true;
			    }
			    else if (btnCreate.getImpact(x, y))
			    {
				    btnCreate.glowOn = true;
			    }
			    else if (btnHelp.getImpact(x, y))
			    {
				    btnHelp.glowOn = true;
			    }			
			    else if (btnReturn.getImpact(x, y))
			    {
				    btnReturn.glowOn = true;
			    }
			    break;

            case MouseEventType.EventType.MouseUp:
                x = (int)e.X;
                y = (int)e.Y;
			
			    btnAdd.glowOn = false;
			    btnRemove.glowOn = false;
			    btnLeft.glowOn = false;
			    btnRight.glowOn = false;
			    btnPcListIndex.glowOn = false;
			    btnCreate.glowOn = false;
			    btnHelp.glowOn = false;		
			    btnReturn.glowOn = false;
			
			    if (btnAdd.getImpact(x, y))
			    {
                    gv.PlaySound("btn_click");
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    //add selected PC to partyList and remove from pcList
				    if ((pcList.Count > 0) && (mod.playerList.Count < mod.numberOfPlayerMadePcsAllowed))
				    {
					    Player copyPC = pcList[pcIndex].DeepCopy();
					    copyPC.token = gv.cc.LoadBitmap(copyPC.tokenFilename);
					    copyPC.playerClass = mod.getPlayerClass(copyPC.classTag);
					    copyPC.race = mod.getRace(copyPC.raceTag);
					    mod.playerList.Add(copyPC);
					    pcList.RemoveAt(pcIndex);
				    }
			    }
			    else if (btnRemove.getImpact(x, y))
			    {
                    gv.PlaySound("btn_click");
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    //remove selected from partyList and add to pcList
				    if (mod.playerList.Count > 0)
				    {
					    Player copyPC = mod.playerList[partyScreenPcIndex].DeepCopy();
					    copyPC.token = gv.cc.LoadBitmap(copyPC.tokenFilename);
					    copyPC.playerClass = mod.getPlayerClass(copyPC.classTag);
					    copyPC.race = mod.getRace(copyPC.raceTag);
					    pcList.Add(copyPC);
					    mod.playerList.RemoveAt(partyScreenPcIndex);
				    }
			    }
			    else if (btnLeft.getImpact(x, y))
			    {
                    gv.PlaySound("btn_click");
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    //change index of pcList
				    lastClickedPlayerList = false;
				    if (pcIndex > 0)
				    {
					    pcIndex--;
				    }
			    }
			    else if (btnPcListIndex.getImpact(x, y))
			    {
                    gv.PlaySound("btn_click");
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    //change index of pcList
				    lastClickedPlayerList = false;
			    }
			    else if (btnRight.getImpact(x, y))
			    {
                    gv.PlaySound("btn_click");
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    //change index of pcList
				    lastClickedPlayerList = false;
				    if (pcIndex < pcList.Count-1)
				    {
					    pcIndex++;
				    }
			    }
			    else if (btnCreate.getImpact(x, y))
			    {
                    gv.PlaySound("btn_click");
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    //switch to PcCreation screen
                    gv.screenPcCreation.CreateRaceList();
				    gv.screenPcCreation.resetPC();
				    gv.screenType = "pcCreation";
				    //gv.cc.tutorialPcCreation();
			    }
			
			    else if (btnHelp.getImpact(x, y))
			    {
                    gv.PlaySound("btn_click");
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    tutorialPartyBuild();
			    }
			
			    else if (btnReturn.getImpact(x, y))
			    {
                    gv.PlaySound("btn_click");
				    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
				    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
				    if (mod.playerList.Count > 0)
				    {
					    gv.mod.PlayerLocationX = gv.mod.startingPlayerPositionX;
					    gv.mod.PlayerLocationY = gv.mod.startingPlayerPositionY;
                        mod.playerList[0].mainPc = true;
                        //gv.TrackerSendEventPartyInfo("PartyStart");
                        //gv.TrackerSendEventFullPartyInfo("PartyStart");
                        gv.cc.tutorialMessageMainMap();
			    	    gv.screenType = "main";
			    	    gv.cc.doUpdate();	
				    }
			    }
			    for (int j = 0; j < mod.playerList.Count; j++)
			    {
				    if (btnPartyIndex[j].getImpact(x, y))
				    {
                        gv.PlaySound("btn_click");
					    //if (mod.playButtonSounds) {gv.playSoundEffect(android.view.SoundEffectConstants.CLICK);}
					    //if (mod.playButtonHaptic) {gv.performHapticFeedback(android.view.HapticFeedbackConstants.VIRTUAL_KEY);}
					    partyScreenPcIndex = j;
					    lastClickedPlayerList = true;
				    }
			    }			
			    break;	
		    }
	    }

        public void tutorialPartyBuild()
        {
    	    gv.sf.MessageBoxHtml(this.stringMessagePartyBuild);
        }
    }
}
