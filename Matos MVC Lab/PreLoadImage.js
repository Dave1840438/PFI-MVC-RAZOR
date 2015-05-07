<script>
       function PreLoadImage(e) {
           var imageTarget = document.getElementById("new_img_avatar");
           var input = document.getElementById("FU_Avatar");
           if (imageTarget != null) {
               var fReader = new FileReader();
               fReader.readAsDataURL(input.files[0]);
               fReader.onloadend = function (event) {
                   // the event.target.result contains the image data 
                   imageTarget.src = event.target.result;

               }
           }
           return true;
       }
</script>