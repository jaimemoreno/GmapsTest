using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Gms.Maps;
using Android.Content;
using Android.Gms.Maps.Model;


namespace gMaps_Test
{
    [Activity(Label = "gMaps_Test", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IOnMapReadyCallback
    {
        private GoogleMap nMap;
        protected override void OnCreate(Bundle bundle)
        {

            this.Title = "Party Map";
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            SetUpMap();

            Button btnHybrid = (Button)FindViewById(Resource.Id.btnHybrid);
            Button btnNormal = (Button)FindViewById(Resource.Id.btnNormal);
            Button btnTerrain = (Button)FindViewById(Resource.Id.btnTerrain);
            Button btnSatellite = (Button)FindViewById(Resource.Id.btnSatellite);
            btnHybrid.Click += BtnHybrid_Click;
            btnNormal.Click += BtnNormal_Click;
            btnTerrain.Click += BtnTerrain_Click;
            btnSatellite.Click += BtnSatellite_Click;


        }

        private void BtnSatellite_Click(object sender, EventArgs e)
        {
            nMap.MapType = GoogleMap.MapTypeSatellite;
        }

        private void BtnTerrain_Click(object sender, EventArgs e)
        {
            nMap.MapType = GoogleMap.MapTypeTerrain;
        }

        private void BtnNormal_Click(object sender, EventArgs e)
        {
            nMap.MapType = GoogleMap.MapTypeNormal;
        }

        private void BtnHybrid_Click(object sender, EventArgs e)
        {
          nMap.MapType = GoogleMap.MapTypeHybrid;
        }

        private void SetUpMap()
        {
            if (nMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);

            }

        }

        public void OnMapReady(GoogleMap googleMap)
        {
            nMap = googleMap;
            LatLng latlng1 = new LatLng(39.542039,-119.822745);
            LatLng latlng2 = new LatLng(43.3183, 1.9812);


            //Reno Marker
            MarkerOptions options = new MarkerOptions().SetPosition(latlng1).SetTitle("Brian's Birthday").SetSnippet("Brian turns 21 tonight! byob.");
            nMap.AddMarker(options);

            //Reno Marker
            MarkerOptions options2 = new MarkerOptions().SetPosition(latlng2).SetTitle("Biggest Little Party").SetSnippet("Join us for some fun.");
            nMap.AddMarker(options2);

   

        }


    }
}

