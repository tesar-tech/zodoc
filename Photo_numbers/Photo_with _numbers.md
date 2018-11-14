---
title: Photo with handwritten numbers on a binary image
---

Folder `cisla_ver`contains images of numbers.

![](../cisla_ver.jpg)
Task
====
Convert an image into a binary representation, where the white numbers will be individual and the black background.

# Read an image
Image = imread ('cisla_ver.jpg');
imshow (Image)
! [] (/ media / Image.jpg)
# Convert image to binary
 BW = im2bw(B,0.5); 
 imshow(BW)
![](../media/BW.jpg)
# Erode image
 se = strel('line',10,90);
 erodedBW = imerode(BW, se);
 imshow(erodedBW);
   Create a structured element. And use the imerode feature that splits the object into simpler parts. 
   ![](../media/erodedBW.jpg)
 
# White numbers and black background
bw2 = imcomplement(BW);
imshow(bw2)
![](../media/bw2.jpg)
