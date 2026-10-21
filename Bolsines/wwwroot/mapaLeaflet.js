export function cargarMapa(nuevasLocalizaciones) {
    let mapa = L.map('map').setView({
        lon: -64.81754484681906,
        lat: -41.4547838657288
    }, 4);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 16
    }).addTo(mapa);

    var localizaciones = JSON.parse(String(nuevasLocalizaciones));

    // Carga directa de la capa GeoJSON agregando los tooltips automáticamente
    L.geoJSON(localizaciones, {
        onEachFeature: function (feature, layer) {
            if (feature.properties && feature.properties.name) {
                layer.bindTooltip(feature.properties.name, {
                    permanent: true,
                    offset: [0, 0]
                });
            }
        }
    }).addTo(mapa);

    return "";
}