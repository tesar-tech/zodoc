title: Part of Ursa Major constellation created with MATLAB scatter
lead: Draws stars based on their position and apparent magnitude, also their names and outline of the constellation
Published: 2019-09-15
Tags: [matlab, scatter]
prerequisites: Matlab
Authors: tesar-tech
---
Variable `m` means [apparent magnitude](https://en.wikipedia.org/wiki/Apparent_magnitude).

``` matlab
stars_names = {'Merak', 'Dubhe','Phecda','Megrez','Alioth','Mizar','Alkaid'};
m = [2.37, 1.79, 2.44, 3.312, 1.77, 3.88 ,1.86];
F0 = 500;
flux_density =power(10, -m/2.5 + log10(F0));

x = [337,316,249,205,146,83,29]; %coordinates of stars from an obrazku
y = [147,205,103,151,131,125,65];

scatter(x,y,flux_density,'w*')

axis([0,384,0,285]);
set(gca,'Color','k','XTick',[],'YTick',[])
text(x+5,y-4,stars_names,'Color',[0 1 0.8],'FontSize',8)
hold on;
order_for_outline = [4,3,1,2,4,5,6,7];
plot(x(order_for_outline),y(order_for_outline),'LineWidth',1)
pbaspect([348 285 1])%keeps aspect ratio
```