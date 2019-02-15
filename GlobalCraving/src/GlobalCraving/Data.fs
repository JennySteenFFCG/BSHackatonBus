module Data
module DummyData =
    open Models

    let burgerMenu =
        let burger1 = {
            burgerKey= "BigWhack"
            name = "Big Whack"
            bread = "White Bread"
            meatType = "Carnivore"
            meatSize = 150
            extras = ["Cheese"]
        }
        let burger2 = {
            burgerKey= "BigWheg"
            name = "Big Wheg"
            bread = "Rye Bread"
            meatType = "Vegetarian"
            meatSize = 150
            extras = ["Cheese";"Tomato"]
        }
        [burger1;burger2]