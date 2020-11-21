# 0x0D. Unity - ShaderGraph

![alt text](https://realtimevfx.com/uploads/default/original/2X/f/f80c1a334908d00e091da7ba5af53e0acb3b0ac3.png)

## What you should learn

- What is rendering
- What is a render pipeline
- What is Unity’s Scriptable Render Pipeline
- What is a shader
- What is ShaderGraph and how is it used
- How to setup a new project that utilizes ShaderGraph
- What is the difference between surface, vertex and fragment shaders
- What is UV mapping
- What is vertex animation

## How to Install
Open Unity in latest version and import Package with following link: https://drive.google.com/file/d/18B1S9x127dKmEis1dxhr8RmmVdAOlOLI/view?usp=sharing.

### Task 0. Glow up
Material and shader that makes an untextured 3D GameObject glow around the edges.
You can change the following properties of the shader in the Inspector window:

- Base color
- Glow color
- Glow strength

### Task 1. Pulse
Based on the previous shader, created a new shader where the glow pulses / fades in and out.

You can change the following properties of the shader in the Inspector window:

- Base color
- Glow color
- Minimum glow strength
- Maximum glow strength
- Pulse frequency

### Task 2. Mr. Stark, I don't feel so good

Created a shader that simulates a disintegrating or dissolving effect.

You can change the following properties of the shader in the Inspector window:
- Base color
- Disintegration / dissolving speed
- Scale of disintegrating fragments

### Task 3. Iceman

Created a shader that makes an object look like ice. The object should be partially transparent.

You can change the following properties of the shader in the Inspector window:

- Base color

### Task 4. Hey Cortana, what's UV positioning? 

Created a shader that applies a flickering hologram effect to an object. You must use a Texture in this shader.

You can change the following properties of the shader in the Inspector window:
- Base color
- Texture

### Task 5. Sine of the sea

Created an animated shader that simulates the appearance of water.

You can change the following properties of the shader in the Inspector window:
- Color(s)
- Wave size
- Wave frequency
