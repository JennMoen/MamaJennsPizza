namespace MamaJennsPizza.Services {

    export class PizzaService {
        private PizzaResource;

        public listPizzas() {
            return this.PizzaResource.query();
        }

        public save(pizza) {
            return this.PizzaResource.save(pizza).$promise;
        }

        public getPizza(id) {
            return this.PizzaResource.get({ id: id });
        }

        public deletePizza(id) {
            return this.PizzaResource.delete({ id: id }).$promise;
        }


        constructor($resource: ng.resource.IResourceService) {
            this.PizzaResource = $resource('/api/pizzas/:id');
        }
    }


    angular.module('MamaJennsPizza').service('pizzaService', PizzaService);

}
