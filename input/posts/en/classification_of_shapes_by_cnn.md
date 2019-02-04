title: Classification of shapes by CNN
lead: Use transfer learned Alexnet to classify shapes
Published: 2019-02-04
Tags: [matlab, classification, shapes,alexnet, transfer learning]
prerequisites: [Matlab]
datazooFiles: shapes_transfer_learning_test.png
Authors: [tesar-tech]
---

This is the last part. Previous posts were about [transfer learning](transfer_learning_with_alexnet), and about [creating set of images](creating_an_image_set_with_various_shapes).

In the [previous post](transfer_learning_with_alexnet) we trained our CNN with high accuracy. This sample tests the network on 16 images that are placed in one .png file.

``` matlab
A = imread('shapes16.png');%read image with 16 shapes

%divide image into cells
A_in_cells  = mat2cell(A,[227 227 227 227],[227 227 227 227],[1 1 1]);
ind = 1;
for ii = 1:4 
    for yy = 1:4
        %compose cells to image
        one_shape = cat(3,A_in_cells{ii,yy,1},A_in_cells{ii,yy,2},A_in_cells{ii,yy,3});
        [label,score] = classify(netTransfer,one_shape);%classification
        Classified_images{ind} = insertText(ima{ind},[1 1],... %add label
            cellstr(string(cla(ind)) + " "+ num2str(max(score)*100)+" %"),'FontSize',26);
        ind = ind+1;
    end
end

montage(Classified_images)
```