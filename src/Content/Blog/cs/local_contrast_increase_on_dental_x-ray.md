title: Lokální zvýšení kontrastu na rentgenovém zubním snímku
lead: Nechat uživatele vybrat region a nahradit ho ekvalizovaným
Published: 2018-11-11
Tags: [matlab, dental, x-ray, histogram, contrast]
datazooFiles: [imgs/dental_x-ray.png ]
prerequisites: [Matlab]
Authors: tesar-tech
---

``` matlab
C=imread('dental_x-ray.png');
button=1; 
x=300;y=300; % počáteční pozice
figure;
ax = axes; 

while button==1 % 1 znamená klik levým tlačítkem
    if x>100 && y >100 % vynechá okraje obrázku
        z_ekv=C;
        z_ekv(x-100:x+100,y-100:y+100)=histeq(z_ekv(x-100:x+100,y-100:y+100));
        imshow(z_ekv,'Parent',ax)
    end
    [y,x, button]=ginput(1); % počká na stisk tlačítka
end
```
