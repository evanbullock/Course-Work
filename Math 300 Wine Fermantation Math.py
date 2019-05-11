# -*- coding: utf-8 -*-
"""
Created on Wed Dec  5 11:36:48 2018

@author: Ev
"""

from pylab import *
import sympy as sp
import mpmath as mp
sp.var('x')
sp.var('y')
sp.var('alpha')

#testy=0.*2 #empty list of 2

#this function wasnt needed
def integrand(t):
   xsolv=sp.solve(t,x)
   return xsolv


#Volume
for alp in arange(0.0,0.02+.001,0.001):#between 0.0 and 0.02
    testy=(sp.solve((0.0002017404542*(x*x)+(0.0001303290910*(y*y))/(0.9520444748+alp*y)-1),[y]))    #solve for y
    #DEBUGGING COMMENTS
    #sp.pprint(testx)
    #sp.pprint(testy[1]) #positive solution for y
    #sp.pprint(testy[0])#negative solution for y
    #sp.pprint(testy[1])
    #sp.pprint(testy[1]*testy[1])
    #END of Debug comments
    #print(alp) #debug
    textx=sp.solve(testy[1],x)#solving previous equation for x, to get bounds
    #sp.pprint(textx) #DEBUG
    if alp<0.001:
        lowbnd=textx[0].evalf()#floatingpt of lowerbound
        upbnd=textx[1].evalf() #floatingpt of upperbound
    
    #sp.pprint(textx) #DEBUG
    intg=sp.integrate(testy[1]**2,(x,lowbnd,upbnd)).evalf() #integral, integrate cross section squared from upbnd to lowbnd
    #sp.pprint(intg) #DEBUG
    vol=(pi*intg) #pi times integral of function squared is the disc method for volume.
    
    #NOTICE: when alpha =.015 and .016 the volume is a real number + a complex number,
    #I had to remove those from the plot due to errors with complex 
    #The commented code below would seem to return only the real number, but that still did not return just the real number.
    
    
    
 #   if iscomplex(vol):
  #      vol=vol.real
    if alp==.005:
        savedvol=vol
    print(vol) #print
    
    if alp<.015 or .016<alp: #READ NOTICE ABOVE
        plot(alp,vol,'ro')
        xlabel("alpha values")
        ylabel("volume")
        title("changes in alpha values relative to volume of Wine Tanks")

#QUICK PYTHON MATHS
totalBottles=savedvol/750 #1 cubic cm =1 mL for liquid volume. 
print("Total Bottles of wine that can be made when alpha is 0.005:")
print(totalBottles)
print(savedvol)



#MORE PLOTS    
    
    
#plot the cross section of the tank when α=0.005
#testx=(sp.solve((0.0002017404542*(x*x)+(0.0001303290910*(y*y))/(0.9520444748+0.005*y)-1),[x]))
testy=(sp.solve((0.0002017404542*(x*x)+(0.0001303290910*(y*y))/(0.9520444748+0.005*y)-1),[y]))#solving for y
sp.plot(testy[0],testy[1],(x,-75,75),title="alpha is 0.005") #plot




#plot the cross section of the tank when α=0.0
#testx=(sp.solve((0.0002017404542*(x*x)+(0.0001303290910*(y*y))/(0.9520444748+0.005*y)-1),[x]))
testy=(sp.solve((0.0002017404542*(x*x)+(0.0001303290910*(y*y))/(0.9520444748+0.0*y)-1),[y]))#solving for y
sp.plot(testy[0],testy[1],(x,-75,75),title="alpha is 0.0") #plot


#plot the cross section of the tank when α=0.005
#testx=(sp.solve((0.0002017404542*(x*x)+(0.0001303290910*(y*y))/(0.9520444748+0.005*y)-1),[x]))
testy=(sp.solve((0.0002017404542*(x*x)+(0.0001303290910*(y*y))/(0.9520444748+0.02*y)-1),[y]))#solving for y
sp.plot(testy[0],testy[1],(x,-75,75),title="alpha is 0.02") #plot




