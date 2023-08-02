% Legyen f(x) = cos(x), (-pi <= x <= pi).
% Interpoláljuk a függvényt a -pi, 0, pi alappontokon a tanult globális
% bázisban harmadfokú spline-nal, Hermite-féle peremfeltétellel:
% f'(-pi) = f'(pi) = 0.


% Megoldás:
%
%      xi | -pi | 0 | pi
%   f(xi) |  -1 | 1 | -1
%
% n = 2, l = 3 => n + l = 5 (dim)
%
% p(x) = a*x^3 + b*x^2 + c*x + d
%
% S3(x) = a*x^3 + b*x^2 + c*x + d + ß*(x-0)^3+
% S3'(x) = 3*a*x^2 + 2*b*x + c + 3*ß*(x-0)^2+
%----------------------------------------------------
% S3(-pi) = -a*pi^3 + b*pi^2 - c*pi + d = -1
% S3(0) = d = 1
% S3(pi) = a*pi^3 + b*pi^2 + c*pi + d + ß*pi^3 = -1
% S3'(-pi) = 3*pi^2*a - 2*pi*b + c = 0
% S3'(pi) = 3*pi^2*a + 2*pi*b + c + ß*3*pi^2 = 0

x = [-pi, 0, pi];
y = [-1, 1, -1];

A = [-pi^3, pi^2, -pi, 1, 0;
     0, 0, 0, 1, 0;
     pi^3, pi^2, pi, 1, pi^3;
     3*pi^2, -2*pi, 1, 0, 0;
     3*pi^2, 2*pi, 1, 0, 3*pi^2];

b = [-1, 1, -1, 0, 0]';
c=A\b;
p = c(1:4);

xx=linspace(-pi,pi,100);
pp = polyval(p,xx);
s1 = max(xx-0,0).^3;
ss = pp + s1*c(5);
yy = cos(xx);

plot(x,y,'o', xx,yy, xx,ss)
legend('adatok', 'fv', 'spline')