use RestDataBase

select *from Categories

select *from OrderHeaders


Insert into Categories values('Apetizer')
Insert into Categories values('Main Course')
Insert into Categories values('Desert')
Insert into Categories values('Beverages')

insert into SubCategories values('Veg',2)
insert into SubCategories values('NonVeg',2)

select *from SubCategories

insert into MenuItems values('Papdi Chaat','Papri chat or papri chaat is a popular traditional fast food and street food from the Indian subcontinent.
                              Papdi chat is traditionally prepared using crisp fried dough wafers known as papri, along with boiled chick peas,
							  dahi, tamarind chutny and topped with chat masala and sev','','Spicy',1,1,'20.99')

insert into MenuItems values('Spring Rolls','Spring rolls are a large variety of filled, rolled appetizers or dim sum found in East Asian, South Asian,
                              Middle Eastern and Southeast Asian cuisine. Spring rolls were a seasonal food consumed during the spring, 
							  and started as a pancake filled with the new seasons spring vegetables, a welcome change from the preserved foods of the long winter months','','Very Spicy',1,1,'40.39')


insert into MenuItems values('Paneer Tikka','Paneer tikka is an Indian dish made from chunks of paneer marinated in spices and grilled in a tandoor.
                              It is a vegetarian alternative to chicken tikka and other meat dishes.
							  It is a popular dish that is widely available in India and countries with an Indian diaspora.','','Spicy',2,1,'10.49')
							  
insert into MenuItems values('Chicken Tikka','Chicken tikka is a chicken dish originating in Mughal Empire the Indian subcontinent.
                              The dish is popular in India, Bangladesh and Pakistan.','','Very Spicy',2,2,'15.89')
							  

insert into MenuItems values('Jalebi','Jalebi, is an Indian sweet snack popular all over South and Western Asia.
                             It is made by deep-frying maida flour batter in pretzel or circular shapes, which are then soaked in sugar syrup.
							 This dessert can be served warm or cold','','Not Spicy',3,1,'8.99')

insert into MenuItems values('Bsundi','Basundi is an Indian sweet mostly in Maharashtra, Gujarat, Andhra Pradesh, Telangana, Tamil Nadu and Karnataka.
                              It is a sweetened condensed milk made by boiling milk on low heat until the milk is reduced by half.','','Not Spicy',3,1,'5.99')


insert into MenuItems values('Mango Lassi','Lassi is a popular traditional dahi-based drink or regional name for buttermilk in Jammu, Himachal, Haryana and Punjab.
                              Lassi is a blend of yogurt, water, spices and sometimes fruit.','','Not Spicy',4,1,'10.99')
							  
insert into MenuItems values('Butter Milk','Buttermilk is a fermented dairy drink. Traditionally, it was the liquid left behind after churning butter out of cultured cream.
                              However, most modern buttermilk is cultured. It is common in warm climates where unrefrigerated fresh milk sours quickly.',
							  '','Not Spicy',4,1,'10.89')

select *from MenuItems 


select *from Coupons

update MenuItems Set MImage='~/Images/SpringRolls.Jpg' where MenuItemId=1

update MenuItems Set MImage='~/Images/papdichat.Jpg' where MenuItemId=2

update MenuItems Set MImage='~/Images/paneertikka.Jpg' where MenuItemId=3

update MenuItems Set MImage='~/Images/chickentikka.Jpg' where MenuItemId=4

update MenuItems Set MImage='~/Images/jalebi.Jpg' where MenuItemId=5

update MenuItems Set MImage='~/Images/bsundi.Jpg' where MenuItemId=6

update MenuItems Set MImage='~/Images/mangolassi.Jpg' where MenuItemId=7

update MenuItems Set MImage='~/Images/buttermilk.Jpg' where MenuItemId=8


delete from MenuItems where MenuItemId=9

select *from ShoppingCarts

delete from ShoppingCarts where Count=1