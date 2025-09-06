# Invertible Counterpoint Calculator 🎼

A simple C# console application that calculates **intervallic relationships under inversion**.  

This tool automates a process that normally takes a lot of manual effort: working out which intervals stay consonant or dissonant when voices are inverted at a given interval (e.g., at the octave, tenth, or twelfth).  

Perfect for students of counterpoint, composers, and anyone exploring how to structure **fugues, canons, and invertible counterpoint** without doing all the tedious hand-calculations.

---

## 🔧 How it Works
- You enter a **JV (inversion index)**, e.g. `-3` or `4`.  
- The program computes, for each possible interval:
  - **Fixed Consonances** → intervals that stay consonant after inversion  
  - **Fixed Dissonances** → intervals that stay dissonant after inversion  
  - **Variable Consonances** → intervals that are consonant before inversion but become dissonant after  
  - **Variable Dissonances** → intervals that are dissonant before inversion but become consonant after  
---

## Status & Roadmap

  Current (v1.0)
  
  Supports 2 voices
  
  Classifies consonances/dissonances under inversion
  
  Console-based workflow
  
  Planned Updates
  
  Support for imaginary voices (hidden motion and implied parts)
  
  3-voice inversion analysis
  
  Possible GUI or web interface for easier interaction
  
  More descriptive output (interval names like “Third” instead of raw numbers)
