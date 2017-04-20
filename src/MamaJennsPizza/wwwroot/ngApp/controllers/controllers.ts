namespace MamaJennsPizza.Controllers {

    export class HomeController {
        public message = 'Hello from the home page! Come and look at all your pizzas.';
        public pizzas;
        public pizza;

        public addPizza() {
            this.pizzaService.save(this.pizza).then(() => this.$state.reload()
            );
        }

        constructor(private pizzaService: MamaJennsPizza.Services.PizzaService, private $state: ng.ui.IStateService) {
            this.pizzas = pizzaService.listPizzas();
        }
    }

    export class DetailsController {
        public pizza;

        public editPizza() {
            this.pizzaService.save(this.pizza).then(() => this.$state.reload()
            );
        }

        public deletePizza() {
            this.pizzaService.deletePizza(this.pizza.id).then(() => this.$state.go('home')
            );
        }

        constructor(private pizzaService: MamaJennsPizza.Services.PizzaService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            this.pizza = pizzaService.getPizza($stateParams['id']);
        }
    }



    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
