module Models
[<CLIMutable>]
type BurgerDescription = {
    burgerKey: string
    name: string
    bread: string
    meatType: string
    meatSize: int
    extras: string list
}

[<CLIMutable>]
type BurgerOrder = {
    burgerKey: string
    clientName: string
}

