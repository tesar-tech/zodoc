title: Classification results in barplot
lead: Transform (scale) image using transform function and classify image. Show results in bar plot.
Published: 2020-11-23
Tags: [matlab,imageDatastore, transform, barplot]
prerequisites: [Matlab]
Authors: tesar-tech
---
Easy way hot to show classification results.
  
``` matlab
imds = imageDatastore('football.jpg');%buildin matlab image
imdsT = transform(imds,@(img) imresize(img,[227 227]));%anonymous transform function

[label,score] = classify(net,imdsT); %classification
[maxvalues, ind] = maxk(score', 5);% get 5 most probable classes

names1=categorical(net.Layers(end).ClassNames(ind(:,1))); %get names of classes
names1 = reordercats(names1,string(names1));%otherwise it sorts by initial index

imds.reset();%after this, it starts with first image
subplot 121; imshow(imds.read())
subplot 122;bar(names1,maxvalues(:,1)*100);ylabel('%')
```