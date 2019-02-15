module Domain

type Bread =
    | WhiteBread
    | RyeBread

type MeatSize = int
type Meat =
    | CarnivoreMeat of MeatSize
    | VegMeat of MeatSize

type Extra =
    | Cheese
    | Tomato
    | Onion

type Burger = {
    bread: Bread
    meat: Meat
    extras: Extra list
    }

