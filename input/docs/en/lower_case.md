title: Classify an image using convolutional neural network Alexnet
Description: Using convolutional neural network Alexnet for image classification and evaluation score of possibilities of the algorithm.
---
>This whole document works with [image](/zodoc/assets/img/kytka256.jpg) in `A` variable.

# Alexnet convolutional neural network definition
Convolutional neural network alexnet works with more than one milion images from the ImageNet database. The network is 8 layers deep and can classify images into 1000 object categories, such as keyboard, mouse, pencil, and many animals.
Result of classification of a image is a name (what is on that image) and percentage value of success by classify in to category.


# Install toolbox model Alexnet in to matlab
```matlab
alexnet 
%type in to command line and follow instructions
%you must have account on https://www.mathworks.com/
```

# Load alexnet in to variable and classify an image
```matlab
net = alexnet; %load neural network in to variable
A = imread('kytka256.jpg'); %load an image
A_resized = imresize(A,[227 227]); %resize image to 227px 227px on input
[label,score] = classify(net,A_resized); % classify and image, the name its
%saved in to variable label and the value of success in to variable score
[maxvalues, ind] = maxk(score(:), 5); %save in next variable five most successed classification
maxvalues=round(maxvalues,3)*100; %rounding and multiplication for properly percentage
values=num2cell(maxvalues);
names=(net.Layers(end).ClassNames(ind)); %save five topmost names by classification
f = subplot(122) %next part for making a nice table of other top classifications
uit = uitable(f);
t=[names,values];
uit.Data= t;
uit.Position = [290 150 150 130]; 
uit.ColumnName = {'Name','Value %'};
subplot 121; imshow(A_resized); %display original image 
title(string(label) + ", " + num2str(max(score)*100,3) + "%"); % display name and percentage
```
![](../media/2018-11-15-0-0-0.jpg)

# Result
As the result of this code is and image and a table. Image with title and percentage of success of classification and a table with five most likely classification with percentage of success.
In this example alexnet evaluated used image as daisy, but in the fact it is a bloom of topinambura

Convolutional neural networks has good prospects in the future, but we have to teach networks like alexnet.

