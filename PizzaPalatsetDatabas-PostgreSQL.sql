--
-- PostgreSQL database dump
--

-- Dumped from database version 12.1 (Debian 12.1-1.pgdg100+1)
-- Dumped by pg_dump version 12.0

-- Started on 2020-02-10 09:15:11

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 256 (class 1255 OID 16775)
-- Name: AddDrink(character varying, integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."AddDrink"(name1 character varying, price integer) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
	INSERT INTO "Drink"("Name","Price") VALUES (name1,price);
END;
$$;


ALTER FUNCTION public."AddDrink"(name1 character varying, price integer) OWNER TO grupp1;

--
-- TOC entry 258 (class 1255 OID 16779)
-- Name: AddEmployee(character varying, character varying, integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."AddEmployee"(name1 character varying, passcode character varying, employeetype integer) RETURNS void
    LANGUAGE plpgsql
    AS $$ 
BEGIN
INSERT INTO "Employee"("Name", "Password", "EmployeeType")
VALUES(name1, passcode, employeetype);

END;$$;


ALTER FUNCTION public."AddEmployee"(name1 character varying, passcode character varying, employeetype integer) OWNER TO grupp1;

--
-- TOC entry 260 (class 1255 OID 16781)
-- Name: AddExtra(character varying, integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."AddExtra"(name1 character varying, price integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN 
INSERT INTO "Extra"("Name", "Price")
VALUES (name1, price);
END;$$;


ALTER FUNCTION public."AddExtra"(name1 character varying, price integer) OWNER TO grupp1;

--
-- TOC entry 261 (class 1255 OID 16782)
-- Name: AddIngredient(character varying, integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."AddIngredient"(name1 character varying, price integer DEFAULT 5) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN 
INSERT INTO "Ingredient"("Name","Price")
VALUES (name1,price);
END;$$;


ALTER FUNCTION public."AddIngredient"(name1 character varying, price integer) OWNER TO grupp1;

--
-- TOC entry 293 (class 1255 OID 17216)
-- Name: AddOrderToReceipt(integer, timestamp without time zone); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."AddOrderToReceipt"(totalprice integer, date timestamp without time zone) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN
INSERT INTO "Receipt"("TotalPrice","Date")
VALUES (totalprice,date);
END$$;


ALTER FUNCTION public."AddOrderToReceipt"(totalprice integer, date timestamp without time zone) OWNER TO grupp1;

--
-- TOC entry 294 (class 1255 OID 17217)
-- Name: AddOrderToReceipt(character varying, integer, timestamp without time zone); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."AddOrderToReceipt"(json character varying, totalprice integer, date timestamp without time zone) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN
INSERT INTO "Receipt"("OrderInfo","TotalPrice","Date")
VALUES (json,totalprice,date);
END$$;


ALTER FUNCTION public."AddOrderToReceipt"(json character varying, totalprice integer, date timestamp without time zone) OWNER TO grupp1;

--
-- TOC entry 262 (class 1255 OID 16783)
-- Name: AddPasta(character varying, integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."AddPasta"(name1 character varying, price integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN 
INSERT INTO "Pasta"("Name", "Price")
VALUES(name1, price);
END;$$;


ALTER FUNCTION public."AddPasta"(name1 character varying, price integer) OWNER TO grupp1;

--
-- TOC entry 263 (class 1255 OID 16785)
-- Name: AddPizza(character varying, integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."AddPizza"(name1 character varying, price integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN
INSERT INTO "Pizza"("Name", "Price") 
VALUES (name1, price);
END;$$;


ALTER FUNCTION public."AddPizza"(name1 character varying, price integer) OWNER TO grupp1;

--
-- TOC entry 264 (class 1255 OID 16786)
-- Name: AddSallad(character varying, integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."AddSallad"(name1 character varying, price integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN
INSERT INTO "Sallad"("Name", "Price")
VALUES (name1,price);
END;$$;


ALTER FUNCTION public."AddSallad"(name1 character varying, price integer) OWNER TO grupp1;

--
-- TOC entry 286 (class 1255 OID 17131)
-- Name: CreateNewOrder(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."CreateNewOrder"(value integer DEFAULT 1) RETURNS TABLE("ID" integer, "Status" integer, "EmployeeID" integer)
    LANGUAGE plpgsql
    AS $$BEGIN
INSERT INTO "Order"("Status") 
VALUES ("value");
RETURN QUERY (SELECT * FROM "Order"
ORDER BY "ID" DESC
LIMIT 1);
END$$;


ALTER FUNCTION public."CreateNewOrder"(value integer) OWNER TO grupp1;

--
-- TOC entry 252 (class 1255 OID 16771)
-- Name: DeleteDrink(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."DeleteDrink"(inid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN
DELETE
FROM 
"Drink"
WHERE "ID" = @inID;
END$$;


ALTER FUNCTION public."DeleteDrink"(inid integer) OWNER TO grupp1;

--
-- TOC entry 250 (class 1255 OID 16768)
-- Name: DeleteEmployee(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."DeleteEmployee"(inid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN
DELETE 
FROM
"Employee"
WHERE "ID" = inid;
END;$$;


ALTER FUNCTION public."DeleteEmployee"(inid integer) OWNER TO grupp1;

--
-- TOC entry 251 (class 1255 OID 16769)
-- Name: DeleteExtra(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."DeleteExtra"(inid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN
DELETE FROM
"Extra"
WHERE "ID" = inid;
END;$$;


ALTER FUNCTION public."DeleteExtra"(inid integer) OWNER TO grupp1;

--
-- TOC entry 254 (class 1255 OID 16773)
-- Name: DeleteIngredient(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."DeleteIngredient"(inid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN
DELETE
FROM "Ingredient"
WHERE "ID" = inid;
END;$$;


ALTER FUNCTION public."DeleteIngredient"(inid integer) OWNER TO grupp1;

--
-- TOC entry 255 (class 1255 OID 16774)
-- Name: DeleteOrder(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."DeleteOrder"(inid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN
DELETE
FROM "Order"
WHERE "ID" = inid;
END;$$;


ALTER FUNCTION public."DeleteOrder"(inid integer) OWNER TO grupp1;

--
-- TOC entry 248 (class 1255 OID 16777)
-- Name: DeletePasta(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."DeletePasta"(inid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN
DELETE
FROM "Pasta"
WHERE "ID" = inid;
END;$$;


ALTER FUNCTION public."DeletePasta"(inid integer) OWNER TO grupp1;

--
-- TOC entry 249 (class 1255 OID 16778)
-- Name: DeletePizza(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."DeletePizza"(inid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN
DELETE
FROM "Pizza"
WHERE "ID" = inid;
END$$;


ALTER FUNCTION public."DeletePizza"(inid integer) OWNER TO grupp1;

--
-- TOC entry 259 (class 1255 OID 16780)
-- Name: DeleteSallad(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."DeleteSallad"(inid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN
DELETE
FROM "Sallad"
WHERE "ID" = inid;
END;$$;


ALTER FUNCTION public."DeleteSallad"(inid integer) OWNER TO grupp1;

--
-- TOC entry 279 (class 1255 OID 16937)
-- Name: DisplayCompleteOrder(); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."DisplayCompleteOrder"() RETURNS TABLE(id integer)
    LANGUAGE plpgsql
    AS $$BEGIN
RETURN QUERY
SELECT "Order"."ID" FROM "Order" WHERE "Order"."Status" = 3;
END;$$;


ALTER FUNCTION public."DisplayCompleteOrder"() OWNER TO grupp1;

--
-- TOC entry 280 (class 1255 OID 16940)
-- Name: DisplayOngoingOrder(); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."DisplayOngoingOrder"() RETURNS TABLE(id integer)
    LANGUAGE plpgsql
    AS $$BEGIN
RETURN QUERY
SELECT "Order"."ID" FROM "Order" WHERE "Status" = 2;
END;$$;


ALTER FUNCTION public."DisplayOngoingOrder"() OWNER TO grupp1;

--
-- TOC entry 245 (class 1255 OID 16750)
-- Name: GetAdmins(character varying, character varying); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."GetAdmins"(username character varying, passcode character varying) RETURNS TABLE("ID" integer, "Name" character varying, "Password" character varying, "EmployeeType" integer)
    LANGUAGE plpgsql
    AS $$BEGIN
RETURN QUERY 
SELECT *
FROM "Employee"
WHERE "Employee"."EmployeeType" = 1 and "Employee"."Name" = username and "Employee"."Password" = passcode;
END$$;


ALTER FUNCTION public."GetAdmins"(username character varying, passcode character varying) OWNER TO grupp1;

--
-- TOC entry 247 (class 1255 OID 16756)
-- Name: GetChefs(character varying, character varying); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."GetChefs"(username character varying, passcode character varying) RETURNS TABLE("ID" integer, "Name" character varying, "Password" character varying, "EmployeeType" integer)
    LANGUAGE plpgsql
    AS $$BEGIN
RETURN QUERY 
SELECT *
FROM "Employee"
WHERE "Employee"."EmployeeType" = 2 and "Employee"."Name" = username and "Employee"."Password" = passcode;
END$$;


ALTER FUNCTION public."GetChefs"(username character varying, passcode character varying) OWNER TO grupp1;

--
-- TOC entry 269 (class 1255 OID 16885)
-- Name: GetOrderDrinks(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."GetOrderDrinks"(inid integer) RETURNS TABLE("ID" integer, "Name" character varying, "Price" integer)
    LANGUAGE plpgsql
    AS $$BEGIN
RETURN QUERY 
SELECT "Drink".*
FROM "Drink", "OrderDrink"
WHERE "OrderDrink"."OrderID" = inid and "OrderDrink"."DrinkID"= "Drink"."ID";
END$$;


ALTER FUNCTION public."GetOrderDrinks"(inid integer) OWNER TO grupp1;

--
-- TOC entry 267 (class 1255 OID 16871)
-- Name: GetOrderExtras(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."GetOrderExtras"(inid integer) RETURNS TABLE("ID" integer, "Name" character varying, "Price" integer)
    LANGUAGE plpgsql
    AS $$BEGIN
RETURN QUERY 
SELECT "Extra".*
	FROM "Extra", "OrderExtra"
	WHERE "OrderExtra"."OrderID" = @inid and "OrderExtra"."ExtraID"= "Extra"."ID";
END$$;


ALTER FUNCTION public."GetOrderExtras"(inid integer) OWNER TO grupp1;

--
-- TOC entry 268 (class 1255 OID 16880)
-- Name: GetOrderPastas(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."GetOrderPastas"(inid integer) RETURNS TABLE("ID" integer, "Name" character varying, "Price" integer)
    LANGUAGE plpgsql
    AS $$BEGIN
RETURN QUERY 
SELECT "Pasta".*
	FROM "Pasta", "OrderPasta"
	WHERE "OrderPasta"."OrderID" = inid and "OrderPasta"."PastaID"= "Pasta"."ID";
END$$;


ALTER FUNCTION public."GetOrderPastas"(inid integer) OWNER TO grupp1;

--
-- TOC entry 270 (class 1255 OID 16890)
-- Name: GetOrderPizzas(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."GetOrderPizzas"(inid integer) RETURNS TABLE("ID" integer, "Name" character varying, "Price" integer)
    LANGUAGE plpgsql
    AS $$BEGIN
RETURN QUERY 
SELECT "Pizza".*
	FROM "Pizza", "OrderPizza"
	WHERE "OrderPizza"."OrderID" = inid and "OrderPizza"."PizzaID"= "Pizza"."ID";
END$$;


ALTER FUNCTION public."GetOrderPizzas"(inid integer) OWNER TO grupp1;

--
-- TOC entry 287 (class 1255 OID 17084)
-- Name: GetOrderSallads(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."GetOrderSallads"(inid integer) RETURNS TABLE(id integer, name character varying, "Price" integer)
    LANGUAGE plpgsql
    AS $$BEGIN
RETURN QUERY 
SELECT "Sallad".*
	FROM "Sallad", "OrderSallad"
	WHERE "OrderSallad"."OrderID" = inid and "OrderSallad"."SalladID"= "Sallad"."ID";
END$$;


ALTER FUNCTION public."GetOrderSallads"(inid integer) OWNER TO grupp1;

--
-- TOC entry 266 (class 1255 OID 16863)
-- Name: RemoveDrinkFromOrder(integer, integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."RemoveDrinkFromOrder"(drinkid integer, orderid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN 
DELETE FROM "OrderDrink"
WHERE orderid = OrderID and drinkid = DrinkID;
END;$$;


ALTER FUNCTION public."RemoveDrinkFromOrder"(drinkid integer, orderid integer) OWNER TO grupp1;

--
-- TOC entry 241 (class 1255 OID 16869)
-- Name: RemoveExtraFromOrder(integer, integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."RemoveExtraFromOrder"(orderid integer, extraid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN
DELETE FROM "OrderExtra"
WHERE OrderID = orderid and ExtraID = extraid;
END;$$;


ALTER FUNCTION public."RemoveExtraFromOrder"(orderid integer, extraid integer) OWNER TO grupp1;

--
-- TOC entry 242 (class 1255 OID 16872)
-- Name: RemovePastaFromOrder(integer, integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."RemovePastaFromOrder"(orderid integer, pastaid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN
DELETE FROM "OrderPasta"
WHERE OrderID = orderid and PastaID = pastaid;
END;$$;


ALTER FUNCTION public."RemovePastaFromOrder"(orderid integer, pastaid integer) OWNER TO grupp1;

--
-- TOC entry 243 (class 1255 OID 16877)
-- Name: RemovePizzaFromOrder(integer, integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."RemovePizzaFromOrder"(orderid integer, pizzaid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN 
SELECT DISTINCT OrderID, PizzaID FROM "OrderPizza";
DELETE FROM "OrderPizza"
WHERE OrderID = orderid and PizzaID = pizzaid;
END;$$;


ALTER FUNCTION public."RemovePizzaFromOrder"(orderid integer, pizzaid integer) OWNER TO grupp1;

--
-- TOC entry 244 (class 1255 OID 16882)
-- Name: RemoveSalladFromOrder(integer, integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."RemoveSalladFromOrder"(orderid integer, salladid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN
DELETE FROM "OrderSallad"
WHERE OrderID = orderid and SalladID = salladid;
END;	$$;


ALTER FUNCTION public."RemoveSalladFromOrder"(orderid integer, salladid integer) OWNER TO grupp1;

--
-- TOC entry 253 (class 1255 OID 16772)
-- Name: ShowDrinkByID(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowDrinkByID"(inid integer) RETURNS TABLE(id integer, name character varying, price integer)
    LANGUAGE plpgsql
    AS $$Begin
return query
Select *
From "Drink"
Where "ID" =inid;
End$$;


ALTER FUNCTION public."ShowDrinkByID"(inid integer) OWNER TO grupp1;

--
-- TOC entry 239 (class 1255 OID 16669)
-- Name: ShowDrinks(); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowDrinks"() RETURNS TABLE(id integer, name character varying, price integer)
    LANGUAGE plpgsql
    AS $$Begin
return query
Select *
From "Drink";
End$$;


ALTER FUNCTION public."ShowDrinks"() OWNER TO grupp1;

--
-- TOC entry 238 (class 1255 OID 16667)
-- Name: ShowEmployees(); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowEmployees"() RETURNS TABLE(id integer, name character varying, password character varying, employytype integer)
    LANGUAGE plpgsql
    AS $$Begin
return query 
Select *
From "Employee";
End$$;


ALTER FUNCTION public."ShowEmployees"() OWNER TO grupp1;

--
-- TOC entry 257 (class 1255 OID 16776)
-- Name: ShowExtraByID(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowExtraByID"(inid integer) RETURNS TABLE(id integer, name character varying, price integer)
    LANGUAGE plpgsql
    AS $$Begin
Return query
Select * 
From "Extra"
Where "ID" = inid;
End;$$;


ALTER FUNCTION public."ShowExtraByID"(inid integer) OWNER TO grupp1;

--
-- TOC entry 240 (class 1255 OID 16711)
-- Name: ShowExtras(); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowExtras"() RETURNS TABLE(id integer, name character varying, price integer)
    LANGUAGE plpgsql
    AS $$Begin
return query
Select *
From "Extra";
End$$;


ALTER FUNCTION public."ShowExtras"() OWNER TO grupp1;

--
-- TOC entry 246 (class 1255 OID 16751)
-- Name: ShowFinishedOrderID(); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowFinishedOrderID"() RETURNS TABLE(id integer)
    LANGUAGE plpgsql
    AS $$Begin
return query
select "Order"."ID"
From "Order"
Where "Order"."Status" = 3;
End
$$;


ALTER FUNCTION public."ShowFinishedOrderID"() OWNER TO grupp1;

--
-- TOC entry 288 (class 1255 OID 17099)
-- Name: ShowIngredients(); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowIngredients"() RETURNS TABLE("ID" integer, "Name" character varying, "Price" integer)
    LANGUAGE plpgsql
    AS $$Begin
return query
Select *
From "Ingredient";
End$$;


ALTER FUNCTION public."ShowIngredients"() OWNER TO grupp1;

--
-- TOC entry 265 (class 1255 OID 16862)
-- Name: ShowOngoingOrder(); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowOngoingOrder"() RETURNS TABLE(id integer)
    LANGUAGE plpgsql
    AS $$Begin
return query
Select "Order"."ID"
From "Order"
Where "Order"."Status" =2;
End$$;


ALTER FUNCTION public."ShowOngoingOrder"() OWNER TO grupp1;

--
-- TOC entry 283 (class 1255 OID 17017)
-- Name: ShowOrderByID(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowOrderByID"(inid integer) RETURNS TABLE("ID" integer, "Status" integer, "EmployeeID" integer)
    LANGUAGE plpgsql
    AS $$Begin
return query
Select *
From "Order"
Where "Order"."ID"=inid;
End$$;


ALTER FUNCTION public."ShowOrderByID"(inid integer) OWNER TO grupp1;

--
-- TOC entry 272 (class 1255 OID 16897)
-- Name: ShowOrderByStatus(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowOrderByStatus"(status integer) RETURNS TABLE(id integer, "Status" integer, "EmployeeID" integer)
    LANGUAGE plpgsql
    AS $$Begin
return query
Select *
From "Order"
Where "Order"."Status"=status;
End$$;


ALTER FUNCTION public."ShowOrderByStatus"(status integer) OWNER TO grupp1;

--
-- TOC entry 273 (class 1255 OID 16902)
-- Name: ShowOrders(); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowOrders"() RETURNS TABLE(id integer, "Status" integer, "EmployeeID" integer)
    LANGUAGE plpgsql
    AS $$Begin
return query
Select *
From "Order";
End$$;


ALTER FUNCTION public."ShowOrders"() OWNER TO grupp1;

--
-- TOC entry 275 (class 1255 OID 16905)
-- Name: ShowPastaByID(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowPastaByID"(inid integer) RETURNS TABLE(id integer, name character varying, "Price" integer)
    LANGUAGE plpgsql
    AS $$Begin
return query
Select *
From "Pasta"
Where "Pasta"."ID" = inid;
End;$$;


ALTER FUNCTION public."ShowPastaByID"(inid integer) OWNER TO grupp1;

--
-- TOC entry 276 (class 1255 OID 16908)
-- Name: ShowPastas(); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowPastas"() RETURNS TABLE(id integer, name character varying, "Price" integer)
    LANGUAGE plpgsql
    AS $$Begin
return query
Select *
From "Pasta";
End$$;


ALTER FUNCTION public."ShowPastas"() OWNER TO grupp1;

--
-- TOC entry 271 (class 1255 OID 16893)
-- Name: ShowPizzaByID(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowPizzaByID"(inid integer) RETURNS TABLE("ID" integer, "Name" character varying, "Price" integer)
    LANGUAGE plpgsql
    AS $$BEGIN
RETURN QUERY
SELECT "Pizza".*
FROM "Pizza"
WHERE "Pizza"."ID" = inid;
END;$$;


ALTER FUNCTION public."ShowPizzaByID"(inid integer) OWNER TO grupp1;

--
-- TOC entry 274 (class 1255 OID 16904)
-- Name: ShowPizzaIngredients(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowPizzaIngredients"(inid integer) RETURNS TABLE("ID" integer, "Name" character varying, "Price" integer)
    LANGUAGE plpgsql
    AS $$BEGIN
RETURN QUERY
SELECT "Ingredient".*
FROM "Ingredient", "PizzaIngredients"
WHERE "Ingredient"."ID" = "PizzaIngredients"."IngredientsID"
and "PizzaIngredients"."PizzaID" = inid;
END;$$;


ALTER FUNCTION public."ShowPizzaIngredients"(inid integer) OWNER TO grupp1;

--
-- TOC entry 277 (class 1255 OID 16924)
-- Name: ShowPizzaIngredientsByID(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowPizzaIngredientsByID"(inid integer) RETURNS TABLE("ID" integer, "Name" character varying, "Price" integer)
    LANGUAGE plpgsql
    AS $$BEGIN
RETURN QUERY
SELECT "Ingredient".*
FROM "Ingredient", "PizzaIngredients"
WHERE "Ingredient"."ID" = "PizzaIngredients"."IngredientsID" 
and "PizzaIngredients"."PizzaID" = inid;
END;$$;


ALTER FUNCTION public."ShowPizzaIngredientsByID"(inid integer) OWNER TO grupp1;

--
-- TOC entry 281 (class 1255 OID 16947)
-- Name: ShowPizzas(); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowPizzas"() RETURNS TABLE("ID" integer, "Name" character varying, "Price" integer)
    LANGUAGE plpgsql
    AS $$Begin
return query
SELECT * from "Pizza";
End$$;


ALTER FUNCTION public."ShowPizzas"() OWNER TO grupp1;

--
-- TOC entry 292 (class 1255 OID 17128)
-- Name: ShowSalladByID(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowSalladByID"(inid integer) RETURNS TABLE("ID" integer, "Name" character varying, "Price" integer)
    LANGUAGE plpgsql
    AS $$Begin
Return query
SELECT "Sallad".*
FROM "Sallad"
WHERE "Sallad"."ID" = inid;
End;$$;


ALTER FUNCTION public."ShowSalladByID"(inid integer) OWNER TO grupp1;

--
-- TOC entry 282 (class 1255 OID 16920)
-- Name: ShowSallads(); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."ShowSallads"() RETURNS TABLE(id integer, name character varying, "Price" integer)
    LANGUAGE plpgsql
    AS $$Begin
return query
SELECT * from "Sallad";
End$$;


ALTER FUNCTION public."ShowSallads"() OWNER TO grupp1;

--
-- TOC entry 278 (class 1255 OID 16936)
-- Name: UpdateOrderStatus(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."UpdateOrderStatus"(inid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$
Begin	
Update "Order"
Set "Status" = "Status" +1
Where "Order"."ID"= inid;
End;
$$;


ALTER FUNCTION public."UpdateOrderStatus"(inid integer) OWNER TO grupp1;

--
-- TOC entry 225 (class 1255 OID 16599)
-- Name: increment(integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public.increment(i integer) RETURNS integer
    LANGUAGE plpgsql
    AS $$
BEGIN
  RETURN i + 1;
END;
$$;


ALTER FUNCTION public.increment(i integer) OWNER TO grupp1;

--
-- TOC entry 290 (class 1255 OID 16942)
-- Name: sp_OrderDrink(integer, integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."sp_OrderDrink"(orderid integer, drinkid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN 
	INSERT INTO "OrderDrink"("OrderID", "DrinkID")
	VALUES(orderid, drinkid);
END
$$;


ALTER FUNCTION public."sp_OrderDrink"(orderid integer, drinkid integer) OWNER TO grupp1;

--
-- TOC entry 284 (class 1255 OID 16943)
-- Name: sp_OrderExtra(integer, integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."sp_OrderExtra"(orderid integer, extraid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN 
	INSERT INTO "OrderExtra"("OrderID", "ExtraID")
	VALUES(orderid, extraid);
END
$$;


ALTER FUNCTION public."sp_OrderExtra"(orderid integer, extraid integer) OWNER TO grupp1;

--
-- TOC entry 285 (class 1255 OID 16944)
-- Name: sp_OrderPasta(integer, integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."sp_OrderPasta"(orderid integer, pastaid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN 
	INSERT INTO "OrderPasta"("OrderID", "PastaID")
	VALUES(orderid, pastaid);
END
$$;


ALTER FUNCTION public."sp_OrderPasta"(orderid integer, pastaid integer) OWNER TO grupp1;

--
-- TOC entry 291 (class 1255 OID 16945)
-- Name: sp_OrderPizza(integer, integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."sp_OrderPizza"(orderid integer, pizzaid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN 
	INSERT INTO "OrderPizza"("OrderID", "PizzaID")
	VALUES(orderid, pizzaid);
END
$$;


ALTER FUNCTION public."sp_OrderPizza"(orderid integer, pizzaid integer) OWNER TO grupp1;

--
-- TOC entry 289 (class 1255 OID 16946)
-- Name: sp_OrderSallad(integer, integer); Type: FUNCTION; Schema: public; Owner: grupp1
--

CREATE FUNCTION public."sp_OrderSallad"(orderid integer, salladid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$BEGIN 
	INSERT INTO "OrderSallad"("OrderID", "SalladID")
	VALUES(orderid, salladid);
END
$$;


ALTER FUNCTION public."sp_OrderSallad"(orderid integer, salladid integer) OWNER TO grupp1;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 202 (class 1259 OID 16397)
-- Name: Drink; Type: TABLE; Schema: public; Owner: grupp1
--

CREATE TABLE public."Drink" (
    "ID" integer NOT NULL,
    "Name" character varying(20) NOT NULL,
    "Price" integer NOT NULL
);


ALTER TABLE public."Drink" OWNER TO grupp1;

--
-- TOC entry 219 (class 1259 OID 16615)
-- Name: Drink_ID_seq; Type: SEQUENCE; Schema: public; Owner: grupp1
--

ALTER TABLE public."Drink" ALTER COLUMN "ID" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Drink_ID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 204 (class 1259 OID 16404)
-- Name: Employee; Type: TABLE; Schema: public; Owner: grupp1
--

CREATE TABLE public."Employee" (
    "ID" integer NOT NULL,
    "Name" character varying(20) NOT NULL,
    "Password" character varying(20) NOT NULL,
    "EmployeeType" integer NOT NULL
);


ALTER TABLE public."Employee" OWNER TO grupp1;

--
-- TOC entry 203 (class 1259 OID 16402)
-- Name: Employee_ID_seq; Type: SEQUENCE; Schema: public; Owner: grupp1
--

ALTER TABLE public."Employee" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Employee_ID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 206 (class 1259 OID 16411)
-- Name: Extra; Type: TABLE; Schema: public; Owner: grupp1
--

CREATE TABLE public."Extra" (
    "ID" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "Price" integer NOT NULL
);


ALTER TABLE public."Extra" OWNER TO grupp1;

--
-- TOC entry 205 (class 1259 OID 16409)
-- Name: Extra_ID_seq; Type: SEQUENCE; Schema: public; Owner: grupp1
--

ALTER TABLE public."Extra" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Extra_ID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 208 (class 1259 OID 16418)
-- Name: Ingredient; Type: TABLE; Schema: public; Owner: grupp1
--

CREATE TABLE public."Ingredient" (
    "ID" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "Price" integer NOT NULL
);


ALTER TABLE public."Ingredient" OWNER TO grupp1;

--
-- TOC entry 207 (class 1259 OID 16416)
-- Name: Ingredient_ID_seq; Type: SEQUENCE; Schema: public; Owner: grupp1
--

ALTER TABLE public."Ingredient" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Ingredient_ID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 210 (class 1259 OID 16425)
-- Name: Order; Type: TABLE; Schema: public; Owner: grupp1
--

CREATE TABLE public."Order" (
    "ID" integer NOT NULL,
    "Status" integer NOT NULL,
    "EmployeeID" integer
);


ALTER TABLE public."Order" OWNER TO grupp1;

--
-- TOC entry 224 (class 1259 OID 17137)
-- Name: OrderDrink; Type: TABLE; Schema: public; Owner: grupp1
--

CREATE TABLE public."OrderDrink" (
    "OrderID" integer NOT NULL,
    "DrinkID" integer NOT NULL
);


ALTER TABLE public."OrderDrink" OWNER TO grupp1;

--
-- TOC entry 221 (class 1259 OID 16971)
-- Name: OrderExtra; Type: TABLE; Schema: public; Owner: grupp1
--

CREATE TABLE public."OrderExtra" (
    "OrderID" integer NOT NULL,
    "ExtraID" integer NOT NULL
);


ALTER TABLE public."OrderExtra" OWNER TO grupp1;

--
-- TOC entry 220 (class 1259 OID 16948)
-- Name: OrderPasta; Type: TABLE; Schema: public; Owner: grupp1
--

CREATE TABLE public."OrderPasta" (
    "OrderID" integer NOT NULL,
    "PastaID" integer NOT NULL
);


ALTER TABLE public."OrderPasta" OWNER TO grupp1;

--
-- TOC entry 222 (class 1259 OID 16986)
-- Name: OrderPizza; Type: TABLE; Schema: public; Owner: grupp1
--

CREATE TABLE public."OrderPizza" (
    "OrderID" integer NOT NULL,
    "PizzaID" integer NOT NULL
);


ALTER TABLE public."OrderPizza" OWNER TO grupp1;

--
-- TOC entry 223 (class 1259 OID 17002)
-- Name: OrderSallad; Type: TABLE; Schema: public; Owner: grupp1
--

CREATE TABLE public."OrderSallad" (
    "OrderID" integer NOT NULL,
    "SalladID" integer NOT NULL
);


ALTER TABLE public."OrderSallad" OWNER TO grupp1;

--
-- TOC entry 209 (class 1259 OID 16423)
-- Name: Order_ID_seq; Type: SEQUENCE; Schema: public; Owner: grupp1
--

ALTER TABLE public."Order" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Order_ID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 212 (class 1259 OID 16457)
-- Name: Pasta; Type: TABLE; Schema: public; Owner: grupp1
--

CREATE TABLE public."Pasta" (
    "ID" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "Price" integer NOT NULL
);


ALTER TABLE public."Pasta" OWNER TO grupp1;

--
-- TOC entry 211 (class 1259 OID 16455)
-- Name: Pasta_ID_seq; Type: SEQUENCE; Schema: public; Owner: grupp1
--

ALTER TABLE public."Pasta" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Pasta_ID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 214 (class 1259 OID 16464)
-- Name: Pizza; Type: TABLE; Schema: public; Owner: grupp1
--

CREATE TABLE public."Pizza" (
    "ID" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "Price" integer NOT NULL
);


ALTER TABLE public."Pizza" OWNER TO grupp1;

--
-- TOC entry 215 (class 1259 OID 16469)
-- Name: PizzaIngredients; Type: TABLE; Schema: public; Owner: grupp1
--

CREATE TABLE public."PizzaIngredients" (
    "PizzaID" integer NOT NULL,
    "IngredientsID" integer NOT NULL
);


ALTER TABLE public."PizzaIngredients" OWNER TO grupp1;

--
-- TOC entry 213 (class 1259 OID 16462)
-- Name: Pizza_ID_seq; Type: SEQUENCE; Schema: public; Owner: grupp1
--

ALTER TABLE public."Pizza" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Pizza_ID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 216 (class 1259 OID 16474)
-- Name: Receipt; Type: TABLE; Schema: public; Owner: grupp1
--

CREATE TABLE public."Receipt" (
    "OrderInfo" character varying,
    "TotalPrice" integer,
    "Date" timestamp without time zone
);


ALTER TABLE public."Receipt" OWNER TO grupp1;

--
-- TOC entry 218 (class 1259 OID 16482)
-- Name: Sallad; Type: TABLE; Schema: public; Owner: grupp1
--

CREATE TABLE public."Sallad" (
    "ID" integer NOT NULL,
    "Name" character varying NOT NULL,
    "Price" integer NOT NULL
);


ALTER TABLE public."Sallad" OWNER TO grupp1;

--
-- TOC entry 217 (class 1259 OID 16480)
-- Name: Sallad_ID_seq; Type: SEQUENCE; Schema: public; Owner: grupp1
--

ALTER TABLE public."Sallad" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Sallad_ID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 3074 (class 0 OID 16397)
-- Dependencies: 202
-- Data for Name: Drink; Type: TABLE DATA; Schema: public; Owner: grupp1
--

COPY public."Drink" ("ID", "Name", "Price") FROM stdin;
3	Sprite	30
4	Trocadero	30
7	Kaffe	20
8	Portello	25
11	Trocadero ZeroHero	20
12	Portello	20
\.


--
-- TOC entry 3076 (class 0 OID 16404)
-- Dependencies: 204
-- Data for Name: Employee; Type: TABLE DATA; Schema: public; Owner: grupp1
--

COPY public."Employee" ("ID", "Name", "Password", "EmployeeType") FROM stdin;
1	Tony	admin123	1
3	Giovanna	kassa1	3
4	Giovanni	bagare2	2
5	ba1	ba1	2
6	VD	123	1
7	Chino	bagare8	2
\.


--
-- TOC entry 3078 (class 0 OID 16411)
-- Dependencies: 206
-- Data for Name: Extra; Type: TABLE DATA; Schema: public; Owner: grupp1
--

COPY public."Extra" ("ID", "Name", "Price") FROM stdin;
1	Dressing	10
2	Vitlöksbröd	20
3	Dipp (Valfri)	10
\.


--
-- TOC entry 3080 (class 0 OID 16418)
-- Dependencies: 208
-- Data for Name: Ingredient; Type: TABLE DATA; Schema: public; Owner: grupp1
--

COPY public."Ingredient" ("ID", "Name", "Price") FROM stdin;
1	Skinka	5
2	Ost	5
3	Champinjoner	5
4	Kebab	5
5	Ananas	5
6	Oliver\n	5
7	Basilika	5
8	Lök	5
9	Soltorkade tomater	5
10	Tomat	5
11	Musslor	5
12	Feferoni	5
13	Oxfile	5
14	Rökor	5
15	Kyckling	5
16	Scampi	5
17	Fetaost	5
18	Banan	5
19	Kronärtskocka	5
20	Bearnaisesås	5
21	Vitlöksås	5
22	Kebabsås	5
\.


--
-- TOC entry 3082 (class 0 OID 16425)
-- Dependencies: 210
-- Data for Name: Order; Type: TABLE DATA; Schema: public; Owner: grupp1
--

COPY public."Order" ("ID", "Status", "EmployeeID") FROM stdin;
6	3	\N
13	3	\N
15	3	\N
17	4	\N
24	4	\N
25	3	\N
32	4	\N
33	1	\N
34	1	\N
35	1	\N
3	3	\N
50	2	\N
51	2	\N
52	2	\N
53	2	\N
54	2	\N
55	2	\N
56	2	\N
57	2	\N
58	2	\N
59	2	\N
60	1	\N
61	2	\N
62	2	\N
63	1	\N
64	1	\N
65	1	\N
66	1	\N
67	1	\N
14	2	\N
2	2	\N
4	2	\N
68	1	\N
69	1	\N
70	1	\N
71	1	\N
72	1	\N
49	3	\N
45	12	\N
46	1	\N
47	486	\N
48	1	\N
\.


--
-- TOC entry 3096 (class 0 OID 17137)
-- Dependencies: 224
-- Data for Name: OrderDrink; Type: TABLE DATA; Schema: public; Owner: grupp1
--

COPY public."OrderDrink" ("OrderID", "DrinkID") FROM stdin;
49	11
51	4
53	4
62	11
\.


--
-- TOC entry 3093 (class 0 OID 16971)
-- Dependencies: 221
-- Data for Name: OrderExtra; Type: TABLE DATA; Schema: public; Owner: grupp1
--

COPY public."OrderExtra" ("OrderID", "ExtraID") FROM stdin;
44	3
44	2
52	2
62	2
\.


--
-- TOC entry 3092 (class 0 OID 16948)
-- Dependencies: 220
-- Data for Name: OrderPasta; Type: TABLE DATA; Schema: public; Owner: grupp1
--

COPY public."OrderPasta" ("OrderID", "PastaID") FROM stdin;
44	5
44	1
44	3
1	4
1	12
52	1
55	1
\.


--
-- TOC entry 3094 (class 0 OID 16986)
-- Dependencies: 222
-- Data for Name: OrderPizza; Type: TABLE DATA; Schema: public; Owner: grupp1
--

COPY public."OrderPizza" ("OrderID", "PizzaID") FROM stdin;
44	2
44	2
44	3
44	2
44	2
51	2
54	1
56	2
57	5
58	5
59	1
61	2
61	1
62	2
\.


--
-- TOC entry 3095 (class 0 OID 17002)
-- Dependencies: 223
-- Data for Name: OrderSallad; Type: TABLE DATA; Schema: public; Owner: grupp1
--

COPY public."OrderSallad" ("OrderID", "SalladID") FROM stdin;
44	2
4	6
44	3
44	3
44	2
44	3
44	5
44	2
44	3
44	3
50	3
51	3
62	4
\.


--
-- TOC entry 3084 (class 0 OID 16457)
-- Dependencies: 212
-- Data for Name: Pasta; Type: TABLE DATA; Schema: public; Owner: grupp1
--

COPY public."Pasta" ("ID", "Name", "Price") FROM stdin;
1	Aglio Olio	75
2	Carbonara	85
3	Frutti di Mare	95
4	Pasta con Pesto	105
5	Pasta con Carne	120
6	delete	12
\.


--
-- TOC entry 3086 (class 0 OID 16464)
-- Dependencies: 214
-- Data for Name: Pizza; Type: TABLE DATA; Schema: public; Owner: grupp1
--

COPY public."Pizza" ("ID", "Name", "Price") FROM stdin;
1	Vesuvio	80
2	KebabPizza	95
3	Hawaii	85
4	Capricciosa	85
5	Margarita	75
\.


--
-- TOC entry 3087 (class 0 OID 16469)
-- Dependencies: 215
-- Data for Name: PizzaIngredients; Type: TABLE DATA; Schema: public; Owner: grupp1
--

COPY public."PizzaIngredients" ("PizzaID", "IngredientsID") FROM stdin;
1	1
1	3
2	2
2	4
2	8
2	10
2	22
3	1
3	2
3	5
5	1
5	2
5	3
4	2
5	16
\.


--
-- TOC entry 3088 (class 0 OID 16474)
-- Dependencies: 216
-- Data for Name: Receipt; Type: TABLE DATA; Schema: public; Owner: grupp1
--

COPY public."Receipt" ("OrderInfo", "TotalPrice", "Date") FROM stdin;
\N	80	2020-02-06 14:17:17.920291
["OrderID : 62","KebabPizza","Kycklingsallad","Trocadero ZeroHero","Vitlöksbröd"]	255	2020-02-07 12:43:55.59951
\.


--
-- TOC entry 3090 (class 0 OID 16482)
-- Dependencies: 218
-- Data for Name: Sallad; Type: TABLE DATA; Schema: public; Owner: grupp1
--

COPY public."Sallad" ("ID", "Name", "Price") FROM stdin;
1	Ost- och skinksallad	120
2	Chevre- och rödbetssallad	120
3	Tacosallad	120
4	Kycklingsallad	120
5	delete	12
6	delete	12
7	delete	12
\.


--
-- TOC entry 3102 (class 0 OID 0)
-- Dependencies: 219
-- Name: Drink_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: grupp1
--

SELECT pg_catalog.setval('public."Drink_ID_seq"', 12, true);


--
-- TOC entry 3103 (class 0 OID 0)
-- Dependencies: 203
-- Name: Employee_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: grupp1
--

SELECT pg_catalog.setval('public."Employee_ID_seq"', 7, true);


--
-- TOC entry 3104 (class 0 OID 0)
-- Dependencies: 205
-- Name: Extra_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: grupp1
--

SELECT pg_catalog.setval('public."Extra_ID_seq"', 4, true);


--
-- TOC entry 3105 (class 0 OID 0)
-- Dependencies: 207
-- Name: Ingredient_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: grupp1
--

SELECT pg_catalog.setval('public."Ingredient_ID_seq"', 32, true);


--
-- TOC entry 3106 (class 0 OID 0)
-- Dependencies: 209
-- Name: Order_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: grupp1
--

SELECT pg_catalog.setval('public."Order_ID_seq"', 72, true);


--
-- TOC entry 3107 (class 0 OID 0)
-- Dependencies: 211
-- Name: Pasta_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: grupp1
--

SELECT pg_catalog.setval('public."Pasta_ID_seq"', 6, true);


--
-- TOC entry 3108 (class 0 OID 0)
-- Dependencies: 213
-- Name: Pizza_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: grupp1
--

SELECT pg_catalog.setval('public."Pizza_ID_seq"', 6, true);


--
-- TOC entry 3109 (class 0 OID 0)
-- Dependencies: 217
-- Name: Sallad_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: grupp1
--

SELECT pg_catalog.setval('public."Sallad_ID_seq"', 7, true);


--
-- TOC entry 2908 (class 2606 OID 16401)
-- Name: Drink Drink_pkey; Type: CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."Drink"
    ADD CONSTRAINT "Drink_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 2910 (class 2606 OID 16408)
-- Name: Employee Employee_pkey; Type: CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."Employee"
    ADD CONSTRAINT "Employee_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 2912 (class 2606 OID 16415)
-- Name: Extra Extra_pkey; Type: CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."Extra"
    ADD CONSTRAINT "Extra_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 2914 (class 2606 OID 16422)
-- Name: Ingredient Ingredient_pkey; Type: CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."Ingredient"
    ADD CONSTRAINT "Ingredient_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 2916 (class 2606 OID 16429)
-- Name: Order Order_pkey; Type: CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."Order"
    ADD CONSTRAINT "Order_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 2919 (class 2606 OID 16461)
-- Name: Pasta Pasta_pkey; Type: CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."Pasta"
    ADD CONSTRAINT "Pasta_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 2923 (class 2606 OID 16473)
-- Name: PizzaIngredients PizzaIngredients_pkey; Type: CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."PizzaIngredients"
    ADD CONSTRAINT "PizzaIngredients_pkey" PRIMARY KEY ("IngredientsID", "PizzaID");


--
-- TOC entry 2921 (class 2606 OID 16468)
-- Name: Pizza Pizza_pkey; Type: CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."Pizza"
    ADD CONSTRAINT "Pizza_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 2927 (class 2606 OID 16489)
-- Name: Sallad Sallad_pkey; Type: CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."Sallad"
    ADD CONSTRAINT "Sallad_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 2929 (class 1259 OID 16984)
-- Name: fki_FK_OrderExtra_Extra; Type: INDEX; Schema: public; Owner: grupp1
--

CREATE INDEX "fki_FK_OrderExtra_Extra" ON public."OrderExtra" USING btree ("ExtraID");


--
-- TOC entry 2930 (class 1259 OID 16985)
-- Name: fki_FK_OrderExtra_Order; Type: INDEX; Schema: public; Owner: grupp1
--

CREATE INDEX "fki_FK_OrderExtra_Order" ON public."OrderExtra" USING btree ("OrderID");


--
-- TOC entry 2928 (class 1259 OID 16961)
-- Name: fki_FK_OrderPasta_Order; Type: INDEX; Schema: public; Owner: grupp1
--

CREATE INDEX "fki_FK_OrderPasta_Order" ON public."OrderPasta" USING btree ("OrderID");


--
-- TOC entry 2931 (class 1259 OID 16999)
-- Name: fki_FK_OrderPizza_Order; Type: INDEX; Schema: public; Owner: grupp1
--

CREATE INDEX "fki_FK_OrderPizza_Order" ON public."OrderPizza" USING btree ("OrderID");


--
-- TOC entry 2932 (class 1259 OID 17000)
-- Name: fki_FK_OrderPizza_Pizza; Type: INDEX; Schema: public; Owner: grupp1
--

CREATE INDEX "fki_FK_OrderPizza_Pizza" ON public."OrderPizza" USING btree ("PizzaID");


--
-- TOC entry 2933 (class 1259 OID 17015)
-- Name: fki_FK_OrderSallad_Order; Type: INDEX; Schema: public; Owner: grupp1
--

CREATE INDEX "fki_FK_OrderSallad_Order" ON public."OrderSallad" USING btree ("OrderID");


--
-- TOC entry 2934 (class 1259 OID 17016)
-- Name: fki_FK_OrderSallad_Sallad; Type: INDEX; Schema: public; Owner: grupp1
--

CREATE INDEX "fki_FK_OrderSallad_Sallad" ON public."OrderSallad" USING btree ("SalladID");


--
-- TOC entry 2917 (class 1259 OID 16501)
-- Name: fki_FK_Order_Employee; Type: INDEX; Schema: public; Owner: grupp1
--

CREATE INDEX "fki_FK_Order_Employee" ON public."Order" USING btree ("EmployeeID");


--
-- TOC entry 2924 (class 1259 OID 16554)
-- Name: fki_FK_PizzaIngredients_Ingredient; Type: INDEX; Schema: public; Owner: grupp1
--

CREATE INDEX "fki_FK_PizzaIngredients_Ingredient" ON public."PizzaIngredients" USING btree ("IngredientsID");


--
-- TOC entry 2925 (class 1259 OID 16560)
-- Name: fki_FK_PizzaIngredients_Pizza; Type: INDEX; Schema: public; Owner: grupp1
--

CREATE INDEX "fki_FK_PizzaIngredients_Pizza" ON public."PizzaIngredients" USING btree ("PizzaID");


--
-- TOC entry 2947 (class 2606 OID 17145)
-- Name: OrderDrink Drink; Type: FK CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."OrderDrink"
    ADD CONSTRAINT "Drink" FOREIGN KEY ("DrinkID") REFERENCES public."Drink"("ID") ON UPDATE CASCADE NOT VALID;


--
-- TOC entry 2941 (class 2606 OID 17194)
-- Name: OrderExtra Extra; Type: FK CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."OrderExtra"
    ADD CONSTRAINT "Extra" FOREIGN KEY ("ExtraID") REFERENCES public."Extra"("ID") ON UPDATE CASCADE NOT VALID;


--
-- TOC entry 2935 (class 2606 OID 16496)
-- Name: Order FK_Order_Employee; Type: FK CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."Order"
    ADD CONSTRAINT "FK_Order_Employee" FOREIGN KEY ("EmployeeID") REFERENCES public."Employee"("ID") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 2936 (class 2606 OID 16549)
-- Name: PizzaIngredients FK_PizzaIngredients_Ingredient; Type: FK CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."PizzaIngredients"
    ADD CONSTRAINT "FK_PizzaIngredients_Ingredient" FOREIGN KEY ("IngredientsID") REFERENCES public."Ingredient"("ID") ON UPDATE CASCADE NOT VALID;


--
-- TOC entry 2937 (class 2606 OID 16555)
-- Name: PizzaIngredients FK_PizzaIngredients_Pizza; Type: FK CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."PizzaIngredients"
    ADD CONSTRAINT "FK_PizzaIngredients_Pizza" FOREIGN KEY ("PizzaID") REFERENCES public."Pizza"("ID") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 2946 (class 2606 OID 17140)
-- Name: OrderDrink Order; Type: FK CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."OrderDrink"
    ADD CONSTRAINT "Order" FOREIGN KEY ("OrderID") REFERENCES public."Order"("ID") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 2940 (class 2606 OID 17154)
-- Name: OrderExtra Order; Type: FK CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."OrderExtra"
    ADD CONSTRAINT "Order" FOREIGN KEY ("OrderID") REFERENCES public."Order"("ID") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 2942 (class 2606 OID 17164)
-- Name: OrderPizza Order; Type: FK CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."OrderPizza"
    ADD CONSTRAINT "Order" FOREIGN KEY ("OrderID") REFERENCES public."Order"("ID") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 2944 (class 2606 OID 17174)
-- Name: OrderSallad Order; Type: FK CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."OrderSallad"
    ADD CONSTRAINT "Order" FOREIGN KEY ("OrderID") REFERENCES public."Order"("ID") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 2938 (class 2606 OID 17184)
-- Name: OrderPasta Order; Type: FK CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."OrderPasta"
    ADD CONSTRAINT "Order" FOREIGN KEY ("OrderID") REFERENCES public."Order"("ID") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 2943 (class 2606 OID 17169)
-- Name: OrderPizza OrderPizza_PizzaID_fkey; Type: FK CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."OrderPizza"
    ADD CONSTRAINT "OrderPizza_PizzaID_fkey" FOREIGN KEY ("PizzaID") REFERENCES public."Pizza"("ID") ON UPDATE CASCADE NOT VALID;


--
-- TOC entry 2939 (class 2606 OID 17189)
-- Name: OrderPasta Pasta; Type: FK CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."OrderPasta"
    ADD CONSTRAINT "Pasta" FOREIGN KEY ("PastaID") REFERENCES public."Pasta"("ID") ON UPDATE CASCADE NOT VALID;


--
-- TOC entry 2945 (class 2606 OID 17179)
-- Name: OrderSallad Sallad; Type: FK CONSTRAINT; Schema: public; Owner: grupp1
--

ALTER TABLE ONLY public."OrderSallad"
    ADD CONSTRAINT "Sallad" FOREIGN KEY ("SalladID") REFERENCES public."Sallad"("ID") ON UPDATE CASCADE NOT VALID;


-- Completed on 2020-02-10 09:15:16

--
-- PostgreSQL database dump complete
--

