# Compressed Network Simulation – Unity Engineer Test

## 👤 Author
🎮(Game Developer)Saad Nadaf

---

## 📌 Overview
This project is a Unity-based technical assignment focused on **data optimization in a simulated multiplayer environment** and **weapon system architecture design**.

The implementation is done as a **local simulation** (no real networking), strictly following the problem requirements.

---

## 🧩 Problem Statement 1: Data Optimization for Networked Movement

### 🎯 Objective
Reduce the amount of data sent from a local player (`MyPlayer`) to a remote player (`RemotePlayer`) while maintaining **smooth movement**.

Normally, player position would be sent as:
- 3 floats (X, Y, Z)
- Total = **96 bits**

This project demonstrates an optimized approach using **compressed data**.

---

### 🛠️ Implementation Details

#### ✔ Player Setup
- **MyPlayer**
  - Controlled using `W`, `A`, `S`, `D`
  - Sends compressed position data
- **RemotePlayer**
  - Receives compressed data
  - Decompresses it
  - Smoothly interpolates movement

#### ✔ Data Compression
- Each position axis is compressed into a **ushort**
- Reduces data size significantly
- Simulates sending optimized data “over the wire”

#### ✔ Smooth Movement
- Remote player movement uses `Vector3.Lerp`
- Ensures visually smooth interpolation

#### ✔ Debug Logging
The console logs include:
- Original position sent
- Size of data sent (in bits)
- Decompressed position received

---

### 📂 Key Scripts
- `MyPlayer.cs`
- `RemotePlayer.cs`
- `PositionCompressor.cs`

---

### 📝 Assumptions
- Simulation is local (no server / networking library used)
- Movement is on a flat plane (Y-axis fixed)
- Precision trade-off is acceptable for movement smoothing

---

## 🧩 Problem Statement 2: Weapon System Architecture

### 🎯 Objective
Design a scalable and clean **weapon system architecture** for a multiplayer shooter game.

---

### 🏗️ Architecture Design

#### 🔹 Player
- Can equip:
  - **2 Primary Weapons**
  - **1 Secondary Weapon**
- Can:
  - Switch weapons
  - Fire the currently equipped weapon

#### 🔹 Weapon (Base Class)
Common weapon properties:
- Weapon Name
- Ammo Count
- Magazine Size
- Fire Rate

Provides:
- Fire logic
- Reload logic
- Extendable structure

#### 🔹 Weapon Types
- `Rifle`
- `Shotgun`

Each weapon overrides behavior where required.

#### 🔹 UI (Logic Only)
- HUD logic to:
  - Display equipped weapons
  - Show current & total ammo
- No actual Unity UI objects required (logic-only implementation)

---

### 📂 Key Scripts
- `Player.cs`
- `Weapon.cs`
- `Rifle.cs`
- `Shotgun.cs`
- `WeaponUI.cs`

---

## ▶️ How to Run the Project

1. Clone the repository
2. Open the project in **Unity (any recent LTS version)**
3. Open the sample scene
4. Press **Play**
5. Use **WASD** to move `MyPlayer`
6. Observe smooth movement and debug logs for `RemotePlayer`

> ⚠️ The `Library/` folder is intentionally excluded. Unity will regenerate it automatically.

---

## 📦 Notes
- No external networking or multiplayer libraries used
- Project structure follows Unity best practices
- Designed to be easily extensible

---

## ✅ Conclusion
This project demonstrates:
- Efficient data compression techniques
- Smooth interpolation for remote movement
- Clean, extensible weapon system architecture
- Production-ready Unity coding practices

---

Thank you for reviewing this project.
