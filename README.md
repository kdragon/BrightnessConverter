# Texture Brightness Adjustment Tool

# While studying Physically Based Rendering (PBR) techniques for a new Unreal Engine 5 project, I discovered workflows that standardize texture brightness levels to ensure consistency throughout asset creation.

# Although automation and scripting within Unreal Engine itself are possible solutions, I developed this external brightness adjustment tool as part of my ongoing study of various brightness correction methodologies and C# .NET programming.

# Currently, the implemented method adjusts texture brightness additively based on a target reference value, which carries a significant risk of brightness clamping. Therefore, it's crucial to carefully consider which brightness adjustment technique aligns best with the project's artistic and technical goals.

# Future improvements may include implementing multiple brightness adjustment methods, histogram matching capabilities, or the option to store unique reference values for individual assets.

