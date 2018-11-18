title: Image classification using alexnet
Description: Convolutional neural network alexnet is used to classify image.
---
>This document works with the [image](/zodoc/assets/img/kytka256.jpg) in `A` variable. It is also necessary to install alexnet add-on. 

Tested image is classified as "daisy", which is not correct because that yellow bloom is Jerusalem artichoke. However "Jerusalem artichoke" is not one of the alexnet classes (there is 1000 of them) and the daisy is fairly similar, so the classification is not completely wrong. Five classifications with topmost score are displayed in the table.

![](../media/2018-11-15-0-0-0.jpg)

```matlab
net = alexnet;
A = imread('kytka256.jpg');
A_resized = imresize(A,[227 227]); %resize image to 227px 227px for cnn input
[label,score] = classify(net,A_resized); % classify the image

[maxvalues, ind] = maxk(score(:), 5); %get five most succesfull classifications

subplot 121; imshow(A_resized); %display original image
title(string(label) + ", " + num2str(max(score)*100,3) + " %"); % display name and percentage

names=(net.Layers(end).ClassNames(ind)); %get label names 
uitable('Data',[names,num2cell(maxvalues*100)],'Position',[290 150 150 130],'ColumnName',{'Class name','Score %'});% create table
```


