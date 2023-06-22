<template>
    <div class="footer">
        <div class="footer-wrapper">
            <div class="created-by">
                <span class="inscriptions-span">Created by:</span>
                <div class="created-by-information">
                    <img alt="Photo" class="photo" src="@/svg/photo-my.svg" />
                    <span class="information-span">Ksenii Markova</span>
                </div>
            </div>
            <div class="contacts">
                <span class="inscriptions-span">Contacts:</span>
                <span class="information-span information-span-contacts">e-mail: kseniimarkova3@gmail.com</span>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">

</script>

<style scoped>
.footer{
    width: 100%;
    display: flex;
    justify-content: center;
    background-color: #DAD3CE;
    padding-bottom: 0.5rem;
}

.footer-wrapper{
    width: 100%;
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: flex-start;
}

.created-by{
    display: flex;
    flex-direction: column;
    justify-content: space-around;
    align-items: center;
    margin-right: 5rem;
}
.created-by-information{
    display: flex;
    justify-content: space-around;
    align-items: center;
}

.contacts{
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
    height: 100%;
}

.information-span{
    font-style: normal;
    font-size: 20px;
    color: rgba(25, 25, 112, 0.8);
    margin-left: 4rem;
}

.information-span-contacts{
    margin-bottom: auto;
    margin-top: auto;
}

.inscriptions-span{
    font-style: normal;
    font-weight: 600;
    font-size: 24px;
}

img{
    height: 5rem;
    border-radius: 8rem;
}
</style>