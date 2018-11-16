title: Filtering binary objects with kmeans
Description: Binarize image, fill holes, clear border and separate unwanted small objects with help of k-means algorithm.
---
>Utilizing the [image](/zodoc/media/tvary.jpg) with shapes of various color and gradient brightness.

The task is to process the image to binary representation containing only the wanted shapes like rectangle, square, triangle, circle or a star. K-means algorithm is used to determine the range for filtering the objects by their size.

![](../media/2018-11-16-20-21-22.png)

``` matlab
A = imread('tvary.png');
Aa = {};
Aa{1} =A; %colorful image
Ag =imadjust(rgb2gray(A));% adujust contrast and convert to grayscale
Aa{2} = Ag;
Aa{3} = imbinarize(Ag,'adaptive','ForegroundPolarity','dark','Sensitivity',0.55); %to black&white image
Aa{4} = imfill(~Aa{end},'holes'); %fill holes
Aa{5} = imclearborder(Aa{end}); % clear object on borders 
%% filtration using k-means
reg_props = regionprops(Aa{5},'area');%get area of every object
areas =  [reg_props.Area]';% get areas to vector 
%hist(areas,30) % display histogram of areas
[indx, ~] = kmeans(areas,3);% separate objects to 3 clusters based on their sizes.
%one cluster includes biger objects, second smaller objects and "noise" object (that we want to exclude)
% are in own cluster.
% (it does not work well for only 2 clusters)

%We don't know in advance which cluster containst the smallest objects
%take the biggest object from every cluster. Min from these 3 objects is
%taken as a limit for filtering.
min_max = min([max(areas(indx==1)),max(areas(indx==2)),max(areas(indx==3)) ]);
Aa{6} = bwareafilt(Aa{5},[min_max+1 Inf]);
%%
montage(Aa,'bordersize',[1 1],'backgroundcolor','green')
```